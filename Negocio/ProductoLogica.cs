using System;
using System.Collections.Generic;

public class ProductoLogica : IProductoLogica
{
    private List<Producto> productos;  

    public ProductoLogica() 
    {
        productos = new List<Producto>();
    }

    public bool Agregar(Producto producto) //Cambiar a void
    {
        if (producto == null)
            return false;
        if (BuscarPorCodigo(producto.Codigo) != null)
            return false;

        productos.Add(producto);
        return true;
    }

    public bool Modificar(Producto producto)
    {
        Producto existente = BuscarPorCodigo(producto.Codigo);
        if (existente == null)
            return false;

        existente.Nombre = producto.Nombre;
        existente.CantidadDisponible = producto.CantidadDisponible;
        existente.Valor = producto.Valor;
        return true;
    }

    public bool Eliminar(string codigo)
    {
        Producto producto = BuscarPorCodigo(codigo);
        if (producto == null)
            return false;

        productos.Remove(producto);
        return true;
    }

    public Producto BuscarPorCodigo(string codigo) 
    {
        return productos.Find(p => p.Codigo.IndexOf(codigo, StringComparison.OrdinalIgnoreCase) >= 0);
    }

    public List<Producto> BuscarPorNombre(string nombre)
    {
        return productos.FindAll(p => p.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0);
    }

    public List<Producto> ListarProductos()
    {
        return new List<Producto>(productos);
    }
}
