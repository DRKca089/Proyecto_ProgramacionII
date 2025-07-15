using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class frmRegistro : Form
    {
        private UsuarioLogica usuarioLogica = new UsuarioLogica();
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            if (!ValidacionCampos.EstanLlenos(txtUsuario, txtContraseña, txtConfirmarContraseña))
            {
                MessageBox.Show("Rellene todos los campos", "Avertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (ValidacionContraseña.EsLongitudValida(txtContraseña.Text) == false)
            {
                MessageBox.Show("La contraseña debe tener al menos 5 caracteres", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidacionContraseña.SonContraseñasIguales(txtContraseña.Text, txtConfirmarContraseña.Text))
            {
                MessageBox.Show("Las contraseñas no son iguales", "Avertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string resultadoValidacion = usuarioLogica.ValidarRegistro(txtUsuario.Text);

            if (resultadoValidacion != "OK")
            {
                MessageBox.Show(resultadoValidacion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Envia los datos necesarios a negocio para crear el usuario y agregarlo
            string resultadoRegistro = usuarioLogica.RegistrarUsuario(txtUsuario.Text, txtContraseña.Text);

            if (resultadoRegistro == "OK")
            {
                MessageBox.Show("Registro exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(resultadoRegistro, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtConfirmarContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnRegistro.PerformClick();
            }
        }
    }
}
