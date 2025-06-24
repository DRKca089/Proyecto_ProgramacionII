using System;
using System.Windows.Forms;

namespace Presentacion.Forms.FormsCliente
{
    public partial class FormTienda : Form
    {
        public FormTienda()
        {
            InitializeComponent();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            FormCompra compra = new FormCompra();
            compra.ShowDialog();
        }
    }
}
