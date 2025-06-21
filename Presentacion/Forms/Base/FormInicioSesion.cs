using Presentacion.Forms;
using System;
using Negocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmInicioSesion : Form
    {

        private UsuarioLogica usuarioLogica = new UsuarioLogica();

        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {

            if (!ValidacionCampos.EstanLlenos(txtUsuario, txtContraseña, cmbRol))
                return;

            string resultado = usuarioLogica.ValidarInicioSesion(txtUsuario.Text, txtContraseña.Text, cmbRol.Text);

            if (resultado == "OK")
            {
                MessageBox.Show("¡Login exitoso!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                Usuario usuario = usuarioLogica.ObtenerUsuario(txtUsuario.Text);
                frmMenu menu = new frmMenu(usuario.UsuarioNombre, usuario.Rol, usuario.Correo);
                menu.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show(resultado, "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (resultado.Contains("usuario"))
                    txtUsuario.Focus();
                else if (resultado.Contains("contraseña"))
                    txtContraseña.Focus();
                else if (resultado.Contains("rol"))
                    cmbRol.Focus();
            }
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            frmRegistro registro = new frmRegistro();
            this.Hide();
            registro.ShowDialog();
            this.Show();
        }
    }
}
