using Presentacion.Forms.Cliente;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion.Forms.FormsCliente
{
    
    public partial class frmMisCompras : Form
    {
        private Usuario usuarioActual;
        private CompraLogica compraLogica = new CompraLogica();
        public frmMisCompras(Usuario usuarioActual)
        {
            InitializeComponent();
            this.usuarioActual = usuarioActual;
            this.Load += frmMisCompras_Load;
        }

        private void CargarComprasUsuario()
        {
            List<Compra> compras = compraLogica.ObtenerComprasPorUsuario(usuarioActual.Id);

            dGVCompras.AutoGenerateColumns = false;
            dGVCompras.DataSource = compras;
            lblTotal.Text = $"$ {compraLogica.ObtenerTotalGastadoPorUsuario(usuarioActual.Id):F2}";
        }

        private void frmMisCompras_Load(object sender, System.EventArgs e)
        {
            CargarComprasUsuario();
        }

        private void dGVCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dGVCompras.Columns[e.ColumnIndex].Name == "btnDetalles")
            {
                var compraSeleccionada = (Compra)dGVCompras.Rows[e.RowIndex].DataBoundItem;

                frmDetalleCompra detalleForm = new frmDetalleCompra(compraSeleccionada.Codigo, usuarioActual.Id);
                detalleForm.ShowDialog();
            }
        }
    }
}
