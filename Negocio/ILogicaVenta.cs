using System;
using System.Collections.Generic;

public interface ILogicaVenta
{
    void RegistrarVenta(Venta venta);
    List<Venta> ListarVentas();
}
