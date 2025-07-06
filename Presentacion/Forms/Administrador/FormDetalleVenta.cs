using System.Windows.Forms;

namespace Presentacion.Forms.FormsAdministrador
{
    public partial class frmDetalleVenta : Form
    {
        private string codigoVenta;
        private string idUsuario;
        private CompraLogica compraLogica = new CompraLogica();

        public frmDetalleVenta(string codigoVenta, string idUsuario)
        {
            InitializeComponent();
            this.codigoVenta = codigoVenta;
            this.idUsuario = idUsuario;
        }

        private void frmDetalleVenta_Load(object sender, System.EventArgs e)
        {
            CargarDetalles();
        }

        public void CargarDetalles()
        {
            var detalles = compraLogica.ObtenerDetallesCompra(codigoVenta, idUsuario);
            dGVDetalleVenta.AutoGenerateColumns = false;
            dGVDetalleVenta.Columns.Clear();

            if (detalles != null && detalles.Count > 0)
            {
                dGVDetalleVenta.AutoGenerateColumns = false;
                dGVDetalleVenta.DataSource = detalles;
            }
            else
            {
                MessageBox.Show("No se encontraron detalles para esta venta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dGVDetalleVenta.DataSource = detalles;
        }
    }
}
