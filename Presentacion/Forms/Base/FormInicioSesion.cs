using Negocio;
using Presentacion.Forms;
using System;
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
            {
                MessageBox.Show("Rellene todos los campos");
                return;
            }

            try
            {
                string resultado = usuarioLogica.ValidarInicioSesion(txtUsuario.Text, txtContraseña.Text, cmbRol.Text);

                if (resultado == "OK")
                {
                    Usuario usuario = usuarioLogica.ObtenerUsuario(txtUsuario.Text);

                    if (usuario == null)
                    {
                        MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;  // Aquí evitas que siga el código con usuario null
                    }

                    MessageBox.Show("¡Login exitoso!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    frmMenu menu = new frmMenu(usuario.NombreUsuario, usuario.RolUsuario);
                    menu.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(resultado, "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
        $"Error inesperado en: {ex.TargetSite}\n\nMensaje: {ex.Message}\n\nStackTrace:\n{ex.StackTrace}",
        "Error Detallado",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error);

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
