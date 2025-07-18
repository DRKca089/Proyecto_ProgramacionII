using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Forms.FormsCliente
{
    public partial class frmCompra : Form
    {
        private List<CompraDetalles> carrito;
        private ProductoLogica productoLogica = new ProductoLogica();
        private UsuarioLogica usuarioLogica = new UsuarioLogica();
        private CompraLogica compraLogica = new CompraLogica();
        private Usuario usuarioActual;

        public frmCompra(List<CompraDetalles> productosSeleccionados, Usuario usuario)
        {
            InitializeComponent();
            carrito = productosSeleccionados;
            usuarioActual = usuario;
            CargarDatos();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarDatos()
        {
            dGVCarrito.AutoGenerateColumns = false;
            dGVCarrito.DataSource = carrito;

            decimal totalCompra = carrito.Sum(p => p.Subtotal);
            lblTotal.Text = $"$ {totalCompra:F2}";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal totalCompra = carrito.Sum(p => p.Subtotal);

                if (decimal.Round(usuarioActual.Saldo, 2) < decimal.Round(totalCompra, 2))
                {
                    MessageBox.Show("No tienes saldo suficiente para realizar esta compra.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (var item in carrito)
                {
                    Producto productoOriginal = productoLogica.BuscarPorCodigo(item.CodigoProducto);
                    if (productoOriginal == null)
                    {
                        MessageBox.Show($"Producto {item.NombreProducto} no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (productoOriginal.CantidadDisponible < item.Cantidad)
                    {
                        MessageBox.Show($"No hay suficiente stock para {item.NombreProducto}. Stock actual: {productoOriginal.CantidadDisponible}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                bool ok = usuarioLogica.DescontarSaldo(usuarioActual.Id, totalCompra, out string mensaje, out decimal nuevoSaldo);
                if (!ok)
                {
                    MessageBox.Show($"Error al descontar saldo: {mensaje}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                usuarioActual.Saldo = nuevoSaldo;

                var cantidadesCompradas = carrito.ToDictionary(p => p.CodigoProducto, p => p.Cantidad);
                productoLogica.ActualizarStock(cantidadesCompradas);

                string resultado = compraLogica.RegistrarCompra(usuarioActual.Id, carrito);
                if (resultado != "OK")
                {
                    MessageBox.Show($"Error al descontar saldo: {resultado}","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("¡Gracias por tu compra!", "Compra completada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la compra: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
