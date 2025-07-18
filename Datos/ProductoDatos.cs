using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class ProductoDatos
{
    private const string ArchivoCsv = "productos.csv";

    private List<Producto> productos = new List<Producto>();

    public ProductoDatos()
    {
        CargarDesdeArchivo();
    }

    private void CargarDesdeArchivo()
    {
        productos.Clear();
        if (!File.Exists(ArchivoCsv))
        {
            //Si el archivo no existe, se crea uno nuevo con esta cabecera
            File.WriteAllText(ArchivoCsv, "Codigo,Nombre,CantidadDisponible,Valor" + Environment.NewLine);
            return;
        }

        var lineas = File.ReadAllLines(ArchivoCsv);
        // Ignorar la primera línea  que es la cabecera
        foreach (var linea in lineas.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;
            var campos = linea.Split(',');
            if (campos.Length != 4) continue;

            try
            {
                var producto = new Producto
                {
                    Codigo = campos[0],
                    Nombre = campos[1],
                    CantidadDisponible = int.Parse(campos[2]),
                    PrecioUnitario = decimal.Parse(campos[3], CultureInfo.InvariantCulture)
                };
                productos.Add(producto);
            }
            catch(Exception)
            {
            }
        }
    }

    private void GuardarEnArchivo() 
    {
        var lineas = new List<string>
        {
            "Codigo,Nombre,CantidadDisponible,Valor"
        };
        lineas.AddRange(productos.Select(p => $"{p.Codigo},{p.Nombre},{p.CantidadDisponible},{p.PrecioUnitario.ToString(CultureInfo.InvariantCulture)}"));
        File.WriteAllLines(ArchivoCsv, lineas);
    }

    public List<Producto> ObtenerProductos()
    {
        return productos.ToList();
    }

    public List<Producto> ObtenerProductosConVentas()
    {
        var detalles = LeerDetallesDesdeArchivo("detalle_compras.csv");
        var productos = ObtenerProductos();

        var agrupado = detalles
            .GroupBy(d => d.NombreProducto.Trim())
            .Select(g =>
            {
                var nombreProducto = g.Key;

                var productoOriginal = productos
                    .FirstOrDefault(p => p.Nombre.Trim().Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));

                if (productoOriginal != null)
                {
                    return new Producto
                    {
                        Codigo = productoOriginal.Codigo,
                        Nombre = productoOriginal.Nombre,
                        CantidadVendida = g.Sum(x => x.Cantidad),
                        Ingreso = g.Sum(x => x.Subtotal)
                    };
                }
                else
                {
                    return new Producto
                    {
                        Codigo = "---",
                        Nombre = $"{nombreProducto} (eliminado)",
                        CantidadVendida = g.Sum(x => x.Cantidad),
                        Ingreso = g.Sum(x => x.Subtotal)
                    };
                }
            })
            .ToList();

        return agrupado;
    }


    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
        GuardarEnArchivo();
    }

    // Devuelve los n productos con menor stock
    public List<Producto> ObtenerProductosConMenorStock(int n)
    {
        var todos = LeerProductosDesdeArchivo("productos.csv");
        return todos
            .OrderBy(p => p.CantidadDisponible)
            .Take(n)
            .ToList();
    }

    public void ActualizarProducto(Producto productoActualizado)
    {
        var producto = productos.FirstOrDefault(p => p.Codigo == productoActualizado.Codigo);
        if (producto != null)
        {
            producto.Nombre = productoActualizado.Nombre;
            producto.CantidadDisponible = productoActualizado.CantidadDisponible;
            producto.PrecioUnitario = productoActualizado.PrecioUnitario;
            GuardarEnArchivo();
        }
    }

    public void EliminarProducto(string codigo)
    {
        var producto = productos.FirstOrDefault(p => p.Codigo == codigo);
        if (producto != null)
        {
            productos.Remove(producto);
            GuardarEnArchivo();
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

    // Lee todos los detalles de compra
    private List<CompraDetalles> LeerDetallesDesdeArchivo(string archivo)
    {
        var detalles = new List<CompraDetalles>();
        if (!File.Exists(archivo)) return detalles;

        var lineas = File.ReadAllLines(archivo);
        for (int i = 1; i < lineas.Length; i++)
        {
            var campos = lineas[i].Split(',');
            if (campos.Length < 5) continue;

            detalles.Add(new CompraDetalles
            {
                CodigoProducto = campos[0],
                IdUsuario = campos[1],
                NombreProducto = campos[2],
                Cantidad = int.Parse(campos[3]),
                PrecioUnitario = decimal.Parse(campos[4]),
                Subtotal = int.Parse(campos[3]) * decimal.Parse(campos[4], CultureInfo.InvariantCulture)
            });
        }

        return detalles;
    }

    private List<Producto> LeerProductosDesdeArchivo(string archivo)
    {
        var productos = new List<Producto>();
        if (!File.Exists(archivo)) return productos;

        var lineas = File.ReadAllLines(archivo);
        for (int i = 1; i < lineas.Length; i++)
        {
            var campos = lineas[i].Split(',');
            if (campos.Length < 4) continue;

            productos.Add(new Producto
            {
                Codigo = campos[0],
                Nombre = campos[1],
                CantidadDisponible = int.Parse(campos[2]),
                PrecioUnitario = decimal.Parse(campos[3])
            });
        }

        return productos;
    }
}
