using System;
using System.Collections.Generic;

public class ProductoLogica : IProductoLogica
{
    private List<Producto> productos;  

    public ProductoLogica() //Esto se cambiara cuando se agregue para cargar desde los archivos en clase ProductoDatos
    {
        productos = new List<Producto>(); //Inicia la lista vacia
    }

    public void Agregar(Producto producto)
    {
        if(producto == null)
        {
            throw new Exception("El producto no puede ser nulo");
        }

        foreach (Producto p in productos) //Verifica si ya existe un producto
        {
            if(p.Codigo == producto.Codigo)
            {
                throw new Exception("Ya existe un producto con ese codigo");
            }
        }

        productos.Add(producto); //Luego se cambia
    }

    public void Modificar(Producto producto)
    {
        for (int i = 0; i < productos.Count; i++)
        {
            if (productos[i].Codigo == producto.Codigo)
            {
                productos[i].Nombre = producto.Nombre;
                productos[i].CantidadDisponible = producto.CantidadDisponible;
                productos[i].Valor = producto.Valor;
                return; // Ya se hizo la modificación, se sale del método
            }
        }
    }
    public void Eliminar(string codigo)
    {
        int posicion = -1;
        for (int i = 0; i < productos.Count; i++)
        {
            if(productos[i].Codigo == codigo)
            {
                posicion = i; 
                break;
            }
        }
        if(posicion == -1)
        {
            throw new Exception("Producto no encontrado");
        }
        productos.RemoveAt(posicion); //Luego se modificara
    }
    public Producto BuscarPorCodigo(string codigo)
    {
        foreach(Producto p in productos)
        {
            if(p.Codigo == codigo)
            {
                return p;
            }
        }
        return null;
    }
   public List<Producto> BuscarPorNombre(string nombre)
    {
        List<Producto> encontrados = new List<Producto>();
        foreach(Producto p in productos)
        {
            if (p.Nombre.Contains(nombre))
            {
                encontrados.Add(p);
            }
        }
        return null;
    }
    public List<Producto> ListarProductos()
    {
        List<Producto> listaProducto = new List<Producto>();
        foreach(Producto p in productos)
        {
            listaProducto.Add(p);
        }
        return null;
    }
}
