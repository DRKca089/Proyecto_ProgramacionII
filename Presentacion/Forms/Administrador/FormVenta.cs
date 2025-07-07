using Datos;
using Negocio;
using Presentacion.Forms.Cliente;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FormVenta : Form
    {
        private CompraLogica compraLogica = new CompraLogica();
        private UsuarioDatos usuarioDatos = new UsuarioDatos();
        public FormVenta()
        {
            InitializeComponent();
            CargarVentas();
        }

        private void CargarVentas()
        {
            var compras = compraLogica.ObtenerCompras();
            var usuarios = usuarioDatos.ObtenerUsuarios();

            var lista = compras.Select(compra =>
            {
                var usuario = usuarios.FirstOrDefault(u => u.Id == compra.IdUsuario);
                string nombreUsuario = usuario != null ? usuario.Nombre : "Usuario eliminado";

                compra.NombreUsuario = nombreUsuario;
                return compra;
   
            }).ToList();

            dGVVenta.AutoGenerateColumns = false;
            dGVVenta.DataSource = lista;
        }

        private void dGVVenta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dGVVenta.Columns[e.ColumnIndex].Name == "btnDetalles")
            {
                var compraSeleccionada = (Compra)dGVVenta.Rows[e.RowIndex].DataBoundItem;

                frmDetalleCompra detalleForm = new frmDetalleCompra(compraSeleccionada.Codigo, compraSeleccionada.IdUsuario);
                detalleForm.ShowDialog();
            }
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            if (!ValidacionCampos.EstanLlenos(txtBuscar))
            {
                CargarVentas();
                return;
            }

            var compras = compraLogica.ObtenerComprasPorNombreUsuario(txtBuscar.Text.Trim());

            if (compras.Any())
            {
                dGVVenta.AutoGenerateColumns = false;
                dGVVenta.DataSource = compras;
            }
            else
            {
                MessageBox.Show("No se encontraron compras de ese usuario.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dGVVenta.DataSource = null;
            }
        }
    }
}
