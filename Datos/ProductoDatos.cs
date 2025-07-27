using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class ProductoDatos
{
    private const string ArchivoProductos = "productos.csv";
    private const string ArchivoDetallesCompra = "detalle_compras.csv";
    private static readonly string CabeceraCsvProductos = "Codigo,Nombre,CantidadDisponible,Valor";

    private List<Producto> productos;

    public ProductoDatos()
    {
        productos = CargarProductosDesdeArchivo();
    }

    // Devuelve una copia de la lista actual
    public List<Producto> ObtenerProductos()
    {
        return productos.ToList();
    }

    // Agrega un nuevo producto y lo guarda en el archivo
    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
        GuardarProductosEnArchivo();
    }

    // Actualiza un producto existente y guarda los cambios
    public void ActualizarProducto(Producto productoActualizado)
    {
        var producto = productos.FirstOrDefault(producto => producto.Codigo == productoActualizado.Codigo);
        if (producto != null)
        {
            producto.Nombre = productoActualizado.Nombre;
            producto.CantidadDisponible = productoActualizado.CantidadDisponible;
            producto.PrecioUnitario = productoActualizado.PrecioUnitario;
            GuardarProductosEnArchivo();
        }
    }

    // Elimina un producto por su código y guarda los cambios
    public void EliminarProducto(string codigo)
    {
        var producto = productos.FirstOrDefault(producto => producto.Codigo == codigo);
        if (producto != null)
        {
            productos.Remove(producto);
            GuardarProductosEnArchivo();
        }
    }

    // Busca un producto por su código exacto
    public Producto BuscarPorCodigo(string codigo)
    {
        return productos.FirstOrDefault(producto => producto.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
    }

    // Busca productos por nombre parcial o completo
    public List<Producto> BuscarPorNombre(string nombre)
    {
        return productos.Where(producto => producto.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    // Devuelve los N productos con menor stock disponible
    public List<Producto> ObtenerProductosConMenorStock(int n)
    {
        return productos
            .OrderBy(producto => producto.CantidadDisponible)
            .Take(n)
            .ToList();
    }

    // Devuelve productos con información de ventas (cantidad vendida e ingresos generados)
    public List<Producto> ObtenerProductosConVentas()
    {
        var detalles = CargarDetallesDesdeArchivo();

        var productosConVentas = detalles
            .GroupBy(detalleCompra => detalleCompra.NombreProducto.Trim())
            .Select(grupo =>
            {
                var nombre = grupo.Key;
                var productoOriginal = productos
                    .FirstOrDefault(producto => producto.Nombre.Trim().Equals(nombre, StringComparison.OrdinalIgnoreCase));

                return new Producto
                {
                    Codigo = productoOriginal?.Codigo ?? "---",
                    Nombre = productoOriginal?.Nombre ?? $"{nombre} (eliminado)",
                    CantidadVendida = grupo.Sum(x => x.Cantidad),
                    Ingreso = grupo.Sum(x => x.Subtotal)
                };
            })
            .ToList();

        return productosConVentas;
    }

    // Carga los productos desde el archivo CSV
    private List<Producto> CargarProductosDesdeArchivo()
    {
        var lista = new List<Producto>();

        if (!File.Exists(ArchivoProductos))
        {
            File.WriteAllText(ArchivoProductos, CabeceraCsvProductos + Environment.NewLine);
            return lista;
        }

        var lineas = File.ReadAllLines(ArchivoProductos).Skip(1);
        foreach (var linea in lineas)
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;

            var campos = linea.Split(',');
            if (campos.Length != 4) continue;

            if (int.TryParse(campos[2], out int cantidad) &&
                decimal.TryParse(campos[3], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
            {
                lista.Add(new Producto
                {
                    Codigo = campos[0],
                    Nombre = campos[1],
                    CantidadDisponible = cantidad,
                    PrecioUnitario = valor
                });
            }
        }

        return lista;
    }

    // Guarda la lista de productos en el archivo CSV
    private void GuardarProductosEnArchivo()
    {
        var lineas = new List<string> { CabeceraCsvProductos };
        lineas.AddRange(productos.Select(p =>
            $"{p.Codigo},{p.Nombre},{p.CantidadDisponible},{p.PrecioUnitario.ToString(CultureInfo.InvariantCulture)}"
        ));

        File.WriteAllLines(ArchivoProductos, lineas);
    }

    // Carga los detalles de compra desde el archivo CSV para calcular ventas
    private List<CompraDetalles> CargarDetallesDesdeArchivo()
    {
        var detalles = new List<CompraDetalles>();

        if (!File.Exists(ArchivoDetallesCompra))
            return detalles;

        var lineas = File.ReadAllLines(ArchivoDetallesCompra).Skip(1);
        foreach (var linea in lineas)
        {
            var campos = linea.Split(',');
            if (campos.Length < 5) continue;

            if (int.TryParse(campos[3], out int cantidad) &&
                decimal.TryParse(campos[4], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio))
            {
                detalles.Add(new CompraDetalles
                {
                    CodigoProducto = campos[0],
                    IdUsuario = campos[1],
                    NombreProducto = campos[2],
                    Cantidad = cantidad,
                    PrecioUnitario = precio,
                    Subtotal = cantidad * precio
                });
            }
        }

        return detalles;
    }
}
