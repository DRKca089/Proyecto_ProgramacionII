using System;
public class Compra
{
    public string Codigo { get; set; }
    public string IdUsuario { get; set; }
    public string NombreUsuario { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }

}


public class CompraDetalles
{
    public string CodigoCompra { get; set; }
    public string IdUsuario { get; set; }
    public string CodigoProducto { get; set; }
    public string NombreProducto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal {get; set; }
}

