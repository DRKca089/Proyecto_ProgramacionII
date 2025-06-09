using System;
using System.Collections.Generic;

public interface IReporteLogica
{
    List<Producto> ProductosStockBajo(int limite);
    decimal TotalIngresos();
    List<Producto> ProductosMasVendidos(int popular); //Guarda los productos mas vendidos
}
