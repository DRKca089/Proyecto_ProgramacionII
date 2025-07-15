using System;
using System.Windows.Forms;

namespace Presentacion.Forms.Cliente
{
    public partial class frmDetalleCompra : Form
    {
        private string codigoCompra;
        private string idUsuario;
        private CompraLogica compraLogica = new CompraLogica();
        public frmDetalleCompra(string codigoCompra, string idUsuario)
        {
            InitializeComponent();
            this.codigoCompra = codigoCompra;
            this.Load += frmDetalleCompra_Load;
            this.idUsuario = idUsuario;
        }

        private void frmDetalleCompra_Load(object sender, EventArgs e)
        {
            var detalles = compraLogica.ObtenerDetallesCompra(codigoCompra, idUsuario);

            dGVDetalleCompra.AutoGenerateColumns = false;
            dGVDetalleCompra.DataSource = detalles;
        }

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
