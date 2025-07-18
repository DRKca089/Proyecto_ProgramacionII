using Presentacion.Forms;
using Presentacion.Forms.FormsAdministrador;
using Presentacion.Forms.FormsCliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmMenu : Form
    {
        private UsuarioLogica usuarioLogica = new UsuarioLogica();
        private ProductoLogica productoLogica = new ProductoLogica();
        private Dictionary<string, int> cantidadesSeleccionadas = new Dictionary<string, int>();
        private Form formularioHijoActual;
        private Usuario usuarioActual;

        private string nombreUsuario;
        private string rolUsuario;

        public frmMenu(string nombre, string rol, Usuario usuario)
        {
            InitializeComponent();
            nombreUsuario = nombre;
            rolUsuario = rol;
            lblDatos.Text = $"{rolUsuario}\n\n{nombreUsuario}";
            MostrarOpcionesPorRol();
            usuarioActual = usuario;
        }

        public void RefrescarDatosUsuario(string nuevoNombre)
        {
            nombreUsuario = nuevoNombre;
            lblDatos.Text = $"{rolUsuario}\n\n{nombreUsuario}";
        }
        private void MostrarOpcionesPorRol()
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
                if (formularioHijoActual is frmReporte reporteForm)
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
            AbrirFormularioHijo(new frmEditarUsuario(usuarioActual, this));
        }


        private void btnProducto_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmProducto(productoLogica));
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FormVenta());
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmReporte());
        }

        private void bntTienda_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmTienda(usuarioActual, cantidadesSeleccionadas));
        }

        private void btnMisCompras_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmMisCompras(usuarioActual));
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmGestionUsuario(usuarioActual));
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