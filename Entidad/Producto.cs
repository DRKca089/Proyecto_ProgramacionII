public class Producto
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int CantidadDisponible { get; set; }
    public decimal Valor { get; set; }

}

public class ProductoCompra
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public int Cantidad { get; set; }
    public decimal Total { get; set; }
}