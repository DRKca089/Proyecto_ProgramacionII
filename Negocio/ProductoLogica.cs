using System;
using System.Collections.Generic;

public class ProductoLogica : IProductoLogica
{
    public void Agregar(Producto producto)
    {
        if (producto == null || string.IsNullOrWhiteSpace(producto.Codigo))
            throw new ArgumentNullException("Producto invalido");
    }

    public void Modificar(Producto producto)
    {

    }
    public void Eliminar(string codigo)
    {

    }
    public Producto BuscarPorCodigo(string codigo)
    {
        return null;
    }
   public List<Producto> BuscarPorNombre(string nombre)
    {
        return null;
    }
    public List<Producto> ListarProductos()
    {
        return null;
    }
}
