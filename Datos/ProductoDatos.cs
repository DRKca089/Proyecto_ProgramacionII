using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductoDatos
{
    private static List<Producto> productos = new List<Producto>();

    public List<Producto> ObtenerProductos()
    {
        return productos.ToList();
    }

    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
    }

    public void ActualizarProducto(Producto productoActualizado)
    {
        var producto = productos.FirstOrDefault(p => p.Codigo == productoActualizado.Codigo);
        if (producto != null)
        {
            producto.Nombre = productoActualizado.Nombre;
            producto.CantidadDisponible = productoActualizado.CantidadDisponible;
            producto.Valor = productoActualizado.Valor;
        }
    }

    public void EliminarProducto(string codigo)
    {
        var producto = productos.FirstOrDefault(p => p.Codigo == codigo);
        if (producto != null)
            productos.Remove(producto);
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