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

public interface IVentaLogica
{
    void RegistrarVenta(Venta venta);
    List<Venta> ListarVentas();
}

public interface IReporteLogica
{
    List<Producto> ProductosStockBajo(int limite);
    decimal TotalIngresos();
    List<Producto> ProductosMasVendidos(int popular); //Guarda los productos mas vendidos
}

public interface IUsuarioLogica
{
    string RegistrarUsuario(string usuarioNombre, string contraseña);
    string ValidarInicioSesion(string nombre, string contraseña, string rol);
    string ValidarRegistro(string nombre);
    Usuario ObtenerUsuario(string nombre);
    List<Usuario> ObtenerTodos();
    bool ActualizarUsuario(string id, string nuevoNombre, string nuevaContraseña);
    bool DepositarSaldo(string idUsuario, decimal monto, out string mensaje, out decimal saldoActualizado);

}

