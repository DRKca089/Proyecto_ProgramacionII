using System;
using System.Collections.Generic;
using System.Linq;

public class ProductoLogica : IProductoLogica
{
    private List<Producto> productos;

    public ProductoLogica()
    {
        productos = new List<Producto>();
    }

    public void Agregar(Producto producto)
    {
        ValidarProducto(producto);

        if (productos.Any(p => p.Nombre.Equals(producto.Nombre, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException("Ya existe un producto con ese nombre");

        producto.Codigo = GenerarCodigo();
        productos.Add(producto);
    }

    public void Modificar(Producto producto)
    {
        ValidarProducto(producto, esModificacion: true);

        Producto existente = BuscarPorCodigo(producto.Codigo);
        if (existente == null)
            throw new InvalidOperationException("No se encontró el producto a modificar.");

        existente.Nombre = producto.Nombre;
        existente.CantidadDisponible = producto.CantidadDisponible;
        existente.Valor = producto.Valor;
    }

    public void Eliminar(string codigo)
    {
        Producto productoEliminar = BuscarPorCodigo(codigo);

        if (productoEliminar == null)
            throw new InvalidOperationException("No se encontró el producto a eliminar.");

        productos.Remove(productoEliminar);
    }

    public Producto BuscarPorCodigo(string codigo)
    {
        return productos.Find(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
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
        int siguienteNumero;

        if (productos.Any()) //Verifica si hay algun producto en la lista
        {
            int numeroMaximo = productos.Select(p => int.Parse(p.Codigo.Substring(1))).Max();
            siguienteNumero = numeroMaximo + 1;
        }
        else
        {
            siguienteNumero = 1;
        }

        return "P" + siguienteNumero.ToString("D4");
    }

    private void ValidarProducto(Producto producto, bool esModificacion = false)
    {
        if (producto == null)
            throw new ArgumentNullException(nameof(producto), "El producto no puede estar vacío");

        if (esModificacion)
        {
            if (string.IsNullOrWhiteSpace(producto.Codigo))
                throw new ArgumentException("El código no puede estar vacío.");
        }

        if (string.IsNullOrWhiteSpace(producto.Nombre))
            throw new ArgumentException("El nombre del producto es obligatorio");

        if (producto.CantidadDisponible < 0)
            throw new ArgumentException("La cantidad disponible no puede ser negativo");

        if (producto.Valor < 0)
            throw new ArgumentException("El valor del producto no puede ser negativo");

        if (decimal.Round(producto.Valor, 2) != producto.Valor)
            throw new ArgumentException("El valor solo puede tener hasta 2 decimales");
    }
}
