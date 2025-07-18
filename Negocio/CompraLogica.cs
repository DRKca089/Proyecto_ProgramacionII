using System;
using System.Collections.Generic;
using System.Linq;

public class CompraLogica
{
    private readonly CompraDatos compraDatos = new CompraDatos();
    private readonly DetalleCompraDatos detalleDatos = new DetalleCompraDatos();

    private string GenerarCodigoCompra(string idUsuario)
    {
        var comprasUsuario = compraDatos.ObtenerComprasPorUsuario(idUsuario);
        int siguienteNumero = 1;

        if (comprasUsuario.Any())
        {
            int numeroMaximo = comprasUsuario
                .Select(c => int.Parse(c.Codigo.Substring(1)))
                .Max();

            siguienteNumero = numeroMaximo + 1;
        }

        return "C" + siguienteNumero.ToString("D4");
    }

    public string RegistrarCompra(string idUsuario, List<CompraDetalles> productos)
    {
        if (productos == null || productos.Count == 0)
            return "No hay productos para comprar.";

        string nuevoCodigo = GenerarCodigoCompra(idUsuario);
        decimal total = productos.Sum(p => p.Cantidad * p.PrecioUnitario);

        var compra = new Compra
        {
            Codigo = nuevoCodigo,
            IdUsuario = idUsuario,
            Fecha = DateTime.Now,
            Total = total
        };

        var detallesCompra = productos.Select(p => new CompraDetalles
        {
            CodigoCompra = nuevoCodigo,
            IdUsuario = idUsuario,
            NombreProducto = p.NombreProducto,
            Cantidad = p.Cantidad,
            PrecioUnitario = p.PrecioUnitario,
            Subtotal = p.Cantidad * p.PrecioUnitario
        }).ToList();

        compraDatos.AgregarCompra(compra);
        detalleDatos.AgregarDetalles(detallesCompra);

        return "OK";
    }

    public List<Compra> ObtenerComprasPorNombreUsuario(string nombreUsuario)
    {
        var usuarios = new UsuarioDatos().ObtenerUsuarios();
        var usuariosFiltrados = usuarios
            .Where(u => u.Nombre.IndexOf(nombreUsuario, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();

        var comprasFiltradas = new List<Compra>();

        foreach (var usuario in usuariosFiltrados)
        {
            var comprasUsuario = ObtenerComprasPorUsuario(usuario.Id);

            foreach (var compra in comprasUsuario)
            {
                compra.NombreUsuario = usuario.Nombre;
                comprasFiltradas.Add(compra);
            }
        }

        return comprasFiltradas;
    }

    public decimal ObtenerIngresoTotalVentas()
    {
        var todasCompras = compraDatos.ObtenerCompras();
        return todasCompras.Sum(c => c.Total);
    }

    public decimal ObtenerTotalGastadoPorUsuario(string idUsuario)
    {
        var comprasUsuario = ObtenerComprasPorUsuario(idUsuario);
        return comprasUsuario.Sum(c => c.Total);
    }

    public List<Compra> ObtenerCompras()
    {
        return compraDatos.ObtenerCompras();
    }

    public List<Compra> ObtenerComprasPorUsuario(string idUsuario)
    {
        return compraDatos.ObtenerComprasPorUsuario(idUsuario);
    }

    public List<CompraDetalles> ObtenerDetallesCompra(string codigoCompra, string idUsuario)
    {
        var detalles = detalleDatos.ObtenerDetallesPorCompra(codigoCompra, idUsuario);

        foreach (var detalle in detalles)
        {
            detalle.Subtotal = detalle.Cantidad * detalle.PrecioUnitario;
        }

        return detalles;
    }
}
