using System;
using System.Collections.Generic;
using System.Linq;

public class ProductoLogica
{
    private readonly ProductoDatos productoDatos = new ProductoDatos();

    // Agrega un nuevo producto luego de validar que no esté repetido y genera un nuevo código
    public void Agregar(Producto producto)
    {
        ValidarProducto(producto);

        bool nombreExiste = productoDatos.ObtenerProductos()
            .Any(p => p.Nombre.Equals(producto.Nombre, StringComparison.OrdinalIgnoreCase));

        if (nombreExiste)
            throw new InvalidOperationException("Ya existe un producto con ese nombre.");

        producto.Codigo = GenerarCodigo();
        productoDatos.AgregarProducto(producto);
    }

    // Modifica un producto existente luego de validar sus datos y que no esté repetido el nombre
    public void Modificar(Producto producto)
    {
        ValidarProducto(producto, esModificacion: true);

        var existente = productoDatos.BuscarPorCodigo(producto.Codigo);
        bool nombreRepetido = productoDatos.ObtenerProductos()
            .Any(p => p.Nombre.Equals(producto.Nombre, StringComparison.OrdinalIgnoreCase) && p.Codigo != producto.Codigo);

        if (nombreRepetido)
            throw new InvalidOperationException("Ya existe un producto con ese nombre.");

        if (existente == null)
            throw new InvalidOperationException("No se encontró el producto a modificar.");

        productoDatos.ActualizarProducto(producto);
    }

    // Elimina un producto por su código si existe
    public void Eliminar(string codigo)
    {
        var existente = productoDatos.BuscarPorCodigo(codigo);
        if (existente == null)
            throw new InvalidOperationException("No se encontró el producto a eliminar.");

        productoDatos.EliminarProducto(codigo);
    }

    // Busca un producto por su código
    public Producto BuscarPorCodigo(string codigo) =>
        productoDatos.BuscarPorCodigo(codigo);

    // Busca productos por nombre
    public List<Producto> BuscarPorNombre(string nombre) =>
        productoDatos.BuscarPorNombre(nombre);

    // Lista todos los productos disponibles
    public List<Producto> ListarProductos() =>
        productoDatos.ObtenerProductos();

    // Actualiza el stock de los productos luego de una compra (resta las cantidades compradas)
    public void ActualizarStock(Dictionary<string, int> cantidadesCompradas)
    {
        foreach (var item in cantidadesCompradas)
        {
            var producto = productoDatos.BuscarPorCodigo(item.Key);
            if (producto == null) continue;

            producto.CantidadDisponible -= item.Value;
            if (producto.CantidadDisponible < 0)
                producto.CantidadDisponible = 0;

            productoDatos.ActualizarProducto(producto);
        }
    }

    // Genera una lista de productos seleccionados para una compra con sus cantidades y subtotales
    public List<CompraDetalles> ObtenerProductosParaCompra(List<Producto> productos, Dictionary<string, int> cantidadesSeleccionadas)
    {
        var carrito = new List<CompraDetalles>();

        foreach (var producto in productos)
        {
            if (cantidadesSeleccionadas.TryGetValue(producto.Codigo, out int cantidad) && cantidad > 0)
            {
                carrito.Add(new CompraDetalles
                {
                    CodigoProducto = producto.Codigo,
                    NombreProducto = producto.Nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.PrecioUnitario,
                    Subtotal = producto.PrecioUnitario * cantidad
                });
            }
        }
        return carrito;
    }

    // Obtiene los n productos más vendidos (ordenados de mayor a menor por cantidad vendida)
    public List<Producto> ObtenerProductosMasVendidos(int n)
    {
        var productosConVentas = productoDatos.ObtenerProductosConVentas();
        return productosConVentas.OrderByDescending(producto => producto.CantidadVendida).Take(n).ToList();
    }

    // Obtiene los n productos menos vendidos
    public List<Producto> ObtenerProductosMenosVendidos(int n)
    {
        var productosConVentas = productoDatos.ObtenerProductosConVentas();
        return productosConVentas.OrderBy(producto => producto.CantidadVendida).Take(n).ToList();
    }

    // Obtiene los n productos con menor stock disponible
    public List<Producto> ObtenerProductosConMenorStock(int n) =>
        productoDatos.ObtenerProductosConMenorStock(n);

    // Genera automáticamente un nuevo código de producto
    private string GenerarCodigo()
    {
        var productos = productoDatos.ObtenerProductos();

        int siguienteNumero = 1;
        if (productos.Any())
        {
            int maxNumero = productos.Select(producto => int.Parse(producto.Codigo.Substring(1))).Max();
            siguienteNumero = maxNumero + 1;
        }

        return "P" + siguienteNumero.ToString("D4");
    }

    // Valida los datos del producto antes de agregarlo o modificarlo
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

        if (producto.PrecioUnitario < 0)
            throw new ArgumentException("El valor no puede ser negativo.");

        if (decimal.Round(producto.PrecioUnitario, 2) != producto.PrecioUnitario)
            throw new ArgumentException("El valor debe tener máximo dos decimales.");
    }
}