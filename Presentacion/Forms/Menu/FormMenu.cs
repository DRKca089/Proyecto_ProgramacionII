using Negocio;
using Presentacion.Forms;
using Presentacion.Forms.FormsAdministrador;
using Presentacion.Forms.FormsCliente;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmMenu : Form
    {
        private UsuarioLogica usuarioLogica = new UsuarioLogica();
        private Form formularioHijoActual;
        private string nombreUsuario;
        private string rolUsuario;
        private string correoUsuario;
        public frmMenu(string nombre, string rol, string correo)
        {
            InitializeComponent();
            nombreUsuario = nombre;
            rolUsuario = rol;
            correoUsuario = correo;
            lblDatos.Text = $"{rolUsuario}\n\n{nombreUsuario}\n{correoUsuario}";
            MostrarOpcinesPorRol();
        }

        private void MostrarOpcinesPorRol()
        {
            // Ocultas todos los botones primero
            btnProducto.Visible = false;
            btnVentas.Visible = false;
            btnReporte.Visible = false;
            btnGestionUsuarios.Visible = false;
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
                btnGestionUsuarios.Visible = true;
                lblAdministrador.Visible = true;
            }
            else if (rolUsuario == "Cliente")
            {
                bntTienda.Visible = true;
                btnMisCompras.Visible = true;
                lblCliente.Visible = true;
            }
        }


        private void AbrirFormularioHijo(Form formulariohijo)
        {
            if (formularioHijoActual != null)
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

        private void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = usuarioLogica.ObtenerUsuario(nombreUsuario);
            AbrirFormularioHijo(new frmEditarUsuario(usuario));
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
            AbrirFormularioHijo(new FormTienda());
        }

        private void btnMisCompras_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormMisCompras());
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmGestionUsuario());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Hide();

                if (new frmInicioSesion().ShowDialog() == DialogResult.OK)
                {
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }

    }
}