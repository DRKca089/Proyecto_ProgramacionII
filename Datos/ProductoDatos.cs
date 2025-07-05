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
                    Valor = decimal.Parse(campos[3], CultureInfo.InvariantCulture)
                };
                productos.Add(producto);
            }
            catch(Exception)
            {
                //Joseph ve que podrias agregar aqui
            }
        }
    }

    private void GuardarEnArchivo() 
    {
        var lineas = new List<string>
        {
            "Codigo,Nombre,CantidadDisponible,Valor"
        };
        lineas.AddRange(productos.Select(p => $"{p.Codigo},{p.Nombre},{p.CantidadDisponible},{p.Valor.ToString(CultureInfo.InvariantCulture)}"));
        File.WriteAllLines(ArchivoCsv, lineas);
    }

    public List<Producto> ObtenerProductos()
    {
        return productos.ToList();
    }

    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
        GuardarEnArchivo();
    }

    public void ActualizarProducto(Producto productoActualizado)
    {
        var producto = productos.FirstOrDefault(p => p.Codigo == productoActualizado.Codigo);
        if (producto != null)
        {
            producto.Nombre = productoActualizado.Nombre;
            producto.CantidadDisponible = productoActualizado.CantidadDisponible;
            producto.Valor = productoActualizado.Valor;
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
}
