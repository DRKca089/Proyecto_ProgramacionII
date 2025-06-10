using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Presentacion.Forms;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormMenu : Form
    {

        private Form formularioHijoActual;
        public FormMenu()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AbrirFormularioHijo(Form formulariohijo)
        {
            if(formularioHijoActual != null)
            {
                formularioHijoActual.Close();
            } 
            formularioHijoActual = formulariohijo;
            formulariohijo.TopLevel = false;
            formulariohijo.FormBorderStyle = FormBorderStyle.None;
            formulariohijo.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(formulariohijo);
            panelContenido.Tag = formulariohijo;
            formulariohijo.BringToFront();
            formulariohijo.Show();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormProducto());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormVenta());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormReporte());
        }
    }
}
