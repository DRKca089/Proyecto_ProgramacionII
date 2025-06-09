using System;
using System.Collections.Generic;
public interface IProductoLogica
{
    void Agregar(Producto producto);
    void Modificar(Producto producto);
    void Eliminar(string codigo);
    Producto BuscarPorCodigo(string codigo);
    List<Producto> BuscarPorNombre(string nombre);
    List<Producto> ListarProductos();
}