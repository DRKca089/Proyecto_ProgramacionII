using System;
using System.Collections.Generic;
using System.Linq;

public class Venta
{
    public int NumeroVenta { get; set; }
    public DateTime Fecha { get; set; }
    public List<DetalleVenta> Detalles { get; set; }
    public decimal Total => Detalles.Sum(d => d.Subtotal);
}

public class DetalleVenta
{
    public string CodigoProducto { get; set; }
    public string NombreProducto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal => Cantidad * PrecioUnitario;
}