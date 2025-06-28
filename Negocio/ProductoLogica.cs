using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class ProductoLogica
    {
        private ProductoDatos productoDatos = new ProductoDatos();

        public void Agregar(Producto producto)
        {
            ValidarProducto(producto);

            if (productoDatos.ObtenerProductos()
                .Any(p => p.Nombre.Equals(producto.Nombre, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Ya existe un producto con ese nombre.");
            }
            producto.Codigo = GenerarCodigo();
            productoDatos.AgregarProducto(producto);
        }

        public void Modificar(Producto producto)
        {
            ValidarProducto(producto, esModificacion: true);

            var existente = productoDatos.BuscarPorCodigo(producto.Codigo);
            if (existente == null)
                throw new InvalidOperationException("No se encontró el producto a modificar.");
            productoDatos.ActualizarProducto(producto);
        }

        public void Eliminar(string codigo)
        {
            var existente = productoDatos.BuscarPorCodigo(codigo);
            if (existente == null)
                throw new InvalidOperationException("No se encontró el producto a eliminar.");
            productoDatos.EliminarProducto(codigo);
        }

        public Producto BuscarPorCodigo(string codigo)
        {
            return productoDatos.BuscarPorCodigo(codigo);
        }

        public List<Producto> BuscarPorNombre(string nombre)
        {
            return productoDatos.BuscarPorNombre(nombre);
        }

        public List<Producto> ListarProductos()
        {
            return productoDatos.ObtenerProductos();
        }

        public void ActualizarStock(Dictionary<string, int> cantidadesCompradas)
        {
            foreach (var item in cantidadesCompradas)
            {
                var producto = productoDatos.BuscarPorCodigo(item.Key);
                if (producto != null)
                {
                    producto.CantidadDisponible -= item.Value;
                    if (producto.CantidadDisponible < 0)
                        producto.CantidadDisponible = 0;

                    productoDatos.ActualizarProducto(producto); //Se guarda en el CSV
                }
            }
        }

        public List<ProductoCompra> ObtenerProductosParaCompra(List<Producto> productos, Dictionary<string, int> cantidadesSeleccionadas)
        {
            var carrito = new List<ProductoCompra>();

            foreach (var producto in productos)
            {
                if (cantidadesSeleccionadas.TryGetValue(producto.Codigo, out int cantidad) && cantidad > 0)
                {
                    carrito.Add(new ProductoCompra
                    {
                        Codigo = producto.Codigo,
                        Nombre = producto.Nombre,
                        Cantidad = cantidad,
                        Total = producto.Valor * cantidad
                    });
                }
            }
            return carrito;
        }

        private string GenerarCodigo()
        {
            var productos = productoDatos.ObtenerProductos();
            int siguienteNumero;

            if (productos.Any())
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
                throw new ArgumentNullException(nameof(producto));

            if (esModificacion && string.IsNullOrWhiteSpace(producto.Codigo))
                throw new ArgumentException("El código del producto es obligatorio.");

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (producto.CantidadDisponible < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.");

            if (producto.Valor < 0)
                throw new ArgumentException("El valor no puede ser negativo.");

            if (decimal.Round(producto.Valor, 2) != producto.Valor)
                throw new ArgumentException("El valor debe tener máximo dos decimales.");
        }
    }
}