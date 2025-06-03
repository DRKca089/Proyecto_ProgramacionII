using System;
using System.Collections.Generic;

public class Venta
{
    public int NumeroVenta { get; set; }
    public string CodigoProducto { get; set; }
    public int Cantidad { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total {  get; set; }

    //Contructor sin parametros
    public Venta()
    {
    }
    //Contructor con parametros
    public Venta(int numeroVenta, string codigoProducto, int cantidad, DateTime fecha, decimal total)
    {
        NumeroVenta = numeroVenta;
        CodigoProducto = codigoProducto;
        Cantidad = cantidad;
        Fecha = fecha;
        Total = total;
    }
}