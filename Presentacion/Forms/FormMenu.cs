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
using Presentacion.Forms.FormsCliente;

namespace Presentacion
{
    public partial class frmMenu : Form
    {

        private Form formularioHijoActual;
        private string nombreUsuario;
        private string rolUsuario;
        public frmMenu(string nombre, string rol)
        {
            InitializeComponent();
            nombreUsuario = nombre;
            rolUsuario = rol;
            lblDatos.Text = $"{rolUsuario}\n\n{nombreUsuario}";
            MostrarOpcinesPorRol();
        }

        private void MostrarOpcinesPorRol()
        {
            // Ocultas todos los botones primero
            btnProducto.Visible = false;
            btnVentas.Visible = false;
            btnReporte.Visible = false;
            bntTienda.Visible = false;
            btnMisCompras.Visible = false;
            lblAdministrador.Visible = false;
            lblCliente.Visible = false;

            // Ahora muestras solo los necesarios según el rol
            if (rolUsuario == "Administrador")
            {
                btnProducto.Visible = true;
                btnVentas.Visible = true;
                btnReporte.Visible = true;
                lblAdministrador.Visible = true;
            }
            else if (rolUsuario == "Cliente")
            {
                bntTienda.Visible = true;
                btnMisCompras.Visible = true;
                lblCliente.Visible = true;
            }
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
            AbrirFormularioHijo(new frmProducto());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormVenta());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormReporte());
        }

        private void bntTienda_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmTienda());
        }

        private void btnMisCompras_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmMisCompras());
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

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
