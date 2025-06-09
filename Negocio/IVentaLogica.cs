using System;
using System.Collections.Generic;

public interface IVentaLogica
{
    void RegistrarVenta(Venta venta);
    List<Venta> ListarVentas();
}
