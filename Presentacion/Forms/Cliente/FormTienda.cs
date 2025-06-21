using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
