using System;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FormReporte : Form
    {
        public FormReporte()
        {
            InitializeComponent();
        }

        private void txtNProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnGenerarReporte.PerformClick();
            }
        }
    }
}
