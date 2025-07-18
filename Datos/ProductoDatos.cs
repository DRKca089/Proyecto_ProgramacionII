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

    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
        GuardarProductosEnArchivo();
    }

    public void ActualizarProducto(Producto productoActualizado)
    {
        var producto = productos.FirstOrDefault(p => p.Codigo == productoActualizado.Codigo);
        if (producto != null)
        {
            producto.Nombre = productoActualizado.Nombre;
            producto.CantidadDisponible = productoActualizado.CantidadDisponible;
            producto.PrecioUnitario = productoActualizado.PrecioUnitario;
            GuardarProductosEnArchivo();
        }
    }

    public void EliminarProducto(string codigo)
    {
        var producto = productos.FirstOrDefault(p => p.Codigo == codigo);
        if (producto != null)
        {
            productos.Remove(producto);
            GuardarProductosEnArchivo();
        }
    }

    public Producto BuscarPorCodigo(string codigo)
    {
        return productos.FirstOrDefault(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
    }

    public List<Producto> BuscarPorNombre(string nombre)
    {
        return productos.Where(p => p.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
    }

    public List<Producto> ObtenerProductosConMenorStock(int n)
    {
        return productos
            .OrderBy(p => p.CantidadDisponible)
            .Take(n)
            .ToList();
    }

    public List<Producto> ObtenerProductosConVentas()
    {
        var detalles = CargarDetallesDesdeArchivo();

        var productosConVentas = detalles
            .GroupBy(d => d.NombreProducto.Trim())
            .Select(g =>
            {
                var nombre = g.Key;
                var productoOriginal = productos
                    .FirstOrDefault(p => p.Nombre.Trim().Equals(nombre, StringComparison.OrdinalIgnoreCase));

                return new Producto
                {
                    Codigo = productoOriginal?.Codigo ?? "---",
                    Nombre = productoOriginal?.Nombre ?? $"{nombre} (eliminado)",
                    CantidadVendida = g.Sum(x => x.Cantidad),
                    Ingreso = g.Sum(x => x.Subtotal)
                };
            })
            .ToList();

        return productosConVentas;
    }

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

    private void GuardarProductosEnArchivo()
    {
        var lineas = new List<string> { CabeceraCsvProductos };
        lineas.AddRange(productos.Select(p =>
            $"{p.Codigo},{p.Nombre},{p.CantidadDisponible},{p.PrecioUnitario.ToString(CultureInfo.InvariantCulture)}"
        ));

        File.WriteAllLines(ArchivoProductos, lineas);
    }

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
