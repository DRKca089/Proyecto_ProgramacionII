using Datos;
using System;
using System.Collections.Generic;
using System.Linq;

public class CompraLogica
{
    private CompraDatos compraDatos = new CompraDatos();
    private DetalleCompraDatos detalleDatos = new DetalleCompraDatos();

    private string GenerarCodigoCompra(string idUsuario)
    {
        var comprasUsuario = compraDatos.ObtenerComprasPorUsuario(idUsuario);
        int siguienteNumero;

        if (comprasUsuario.Any())
        {
            int numeroMaximo = comprasUsuario
                .Select(c => int.Parse(c.Codigo.Substring(1)))
                .Max();

            siguienteNumero = numeroMaximo + 1;
        }
        else
        {
            siguienteNumero = 1;
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


        var detalles = productos.Select(p => new CompraDetalles
        {
            CodigoCompra = nuevoCodigo,
            IdUsuario = idUsuario,
            NombreProducto = p.NombreProducto,
            Cantidad = p.Cantidad,
            PrecioUnitario = p.PrecioUnitario,
            Subtotal = p.Cantidad * p.PrecioUnitario
        }).ToList();

        compraDatos.AgregarCompra(compra);
        detalleDatos.AgregarDetalles(detalles);

        return "OK";
    }

    public List<Compra> ObtenerComprasPorNombreUsuario(string nombreUsuario)
    {
        var usuarios = new UsuarioDatos().ObtenerUsuarios();
        var usuario = usuarios.FirstOrDefault(u => u.Nombre.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));

        if (usuario == null)
        {
            return new List<Compra>();
        }

        var compras = ObtenerComprasPorUsuario(usuario.Id);

        foreach (var compra in compras)
        {
            compra.NombreUsuario = usuario.Nombre;
        }

        return compras;
    }

    public decimal ObtenerTotalGastadoPorUsuario(string idUsuario)
    {
        var compras = ObtenerComprasPorUsuario(idUsuario);
        return compras.Sum(c => c.Total);
    }

    public List<Compra> ObtenerCompras()
    {
        return compraDatos.ObtenerCompras();
    }

    public List<Compra> ObtenerComprasPorUsuario(string idUsuario)
    {
        return compraDatos.ObtenerComprasPorUsuario(idUsuario);
    }

    public List<CompraDetalles> ObtenerDetallesCompra(string CodigoCompra, string idUsuario)
    {
        foreach (var d in detalleDatos.ObtenerDetallesPorCompra(CodigoCompra, idUsuario))
        {
            d.Subtotal = d.Cantidad * d.PrecioUnitario;
        }
        return detalleDatos.ObtenerDetallesPorCompra(CodigoCompra, idUsuario);
    }
}