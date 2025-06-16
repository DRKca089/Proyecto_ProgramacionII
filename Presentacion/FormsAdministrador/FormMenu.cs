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
        private string nombreUsuario;
        private string rolUsuario;
        public FormMenu(string nombre, string rol)
        {
            InitializeComponent();
            nombreUsuario = nombre;
            rolUsuario = rol;
            lblDatos.Text = $"{rolUsuario}\n\n{nombreUsuario}";
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
            formulariohijo.TopLevel = false; //FormularioHijo no sera una ventana independiente
            formulariohijo.FormBorderStyle = FormBorderStyle.None; //Se quita el borde y titulo
            formulariohijo.Dock = DockStyle.Fill; //Ocupa todo el espacio del formulario
            panelContenido.Controls.Add(formulariohijo);
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

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Hide();

                if (new FormRegistrarse().ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void lblDatos_Click(object sender, EventArgs e)
        {

        }
    }
}
