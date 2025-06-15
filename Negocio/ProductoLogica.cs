using System;
using System.Collections.Generic;

public class ProductoLogica : IProductoLogica
{
    private List<Producto> productos;

    public ProductoLogica()
    {
        productos = new List<Producto>();
    }

    public void Agregar(Producto producto)
    {
        if (producto == null)
            throw new ArgumentNullException(nameof(producto), "El producto no puede estar vacio");

        if (BuscarPorCodigo(producto.Codigo) != null)
            throw new InvalidOperationException("Ya existe un producto con ese codigo");

        if (producto.CantidadDisponible <= 0)
            throw new ArgumentException("La cantidad disponible no puede ser menor o igual a 0");

        if (producto.Valor <= 0)
            throw new ArgumentException("El valor del producto no puede ser menor o igual a 0");

        producto.Codigo = GenerarCodigo();
        productos.Add(producto);
    }

    public void Modificar(Producto producto)
    {
        Producto existente = BuscarPorCodigo(producto.Codigo);
        if (existente == null)
            throw new InvalidOperationException("No se encontro el producto a modificar");

        if (string.IsNullOrWhiteSpace(producto.Codigo))
            throw new ArgumentException("El código no puede estar vacío.");

        existente.Nombre = producto.Nombre;
        existente.CantidadDisponible = producto.CantidadDisponible;
        existente.Valor = producto.Valor;
    }

    public void Eliminar(string codigo)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("El código no puede estar vacío.");

        Producto producto = BuscarPorCodigo(codigo);
        if (producto == null)
            throw new InvalidOperationException("No se encontró un producto con ese código.");

        productos.Remove(producto);
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

    public string GenerarCodigo()
    {
        {
            int nuevoNumero = 1;
            if (productos.Count > 0)
            {
                string ultimoCodigo = productos[productos.Count - 1].Codigo;
                string numeroStr = ultimoCodigo.Substring(1);
                if (int.TryParse(numeroStr, out int numero))
                    nuevoNumero = numero + 1;
            }
            return "P" + nuevoNumero.ToString("D4");
        }
    }
}
