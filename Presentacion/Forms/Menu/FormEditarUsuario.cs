using Negocio;
using System;
using System.Windows.Forms;

namespace Presentacion.Forms.FormsCliente
{
    public partial class frmEditarUsuario : Form
    {
        private Usuario usuarioActual;
        private UsuarioLogica usuarioLogica = new UsuarioLogica();
        private frmMenu formularioPadre;

        public frmEditarUsuario(Usuario usuario, frmMenu padre)
        {
            InitializeComponent();
            usuarioActual = usuario;
            formularioPadre = padre;
            MostrarDatos();
            Restricciones();
        }

        private void MostrarDatos()
        {
            txtID.Text = usuarioActual.Id;
            txtUsuario.Text = usuarioActual.NombreUsuario;
            txtContraseña.Text = usuarioActual.Contraseña;
            txtSaldo.Text = usuarioActual.Saldo.ToString("C2");
        }

        private void Restricciones()
        {
            bool esAdmin = usuarioActual.RolUsuario.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
            txtMonto.Enabled = !esAdmin;
            btnDepositar.Enabled = !esAdmin;
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            if (!ValidacionNumeros.EsDecimal(txtMonto.Text, out decimal monto))
            {
                MessageBox.Show("El valor debe ser un número decimal válido.");
                return;
            }

            if (usuarioLogica.DepositarSaldo(usuarioActual.Id, monto, out string mensaje, out decimal saldoActualizado))
            {
                usuarioActual.Saldo = saldoActualizado;
                txtSaldo.Text = saldoActualizado.ToString("C2");
                LimpiarFormulario.LimpiarCampos(txtMonto);
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (!ValidacionCampos.EstanLlenos(txtUsuario))
            {
                MessageBox.Show("Rellene todos los campos.");
                return;
            }

            string validacion = usuarioLogica.ValidarRegistro(txtUsuario.Text);

            bool nombreCambió = !txtUsuario.Text.Equals(usuarioActual.NombreUsuario, StringComparison.OrdinalIgnoreCase);

            if (validacion != "OK" &&
                (validacion.Contains("usuario") && nombreCambió))
            {
                MessageBox.Show(validacion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool actualizado = usuarioLogica.ActualizarUsuario(usuarioActual.Id, txtUsuario.Text, usuarioActual.Contraseña);

            if (actualizado)
            {
                usuarioActual.NombreUsuario = txtUsuario.Text;
                formularioPadre.RefrescarDatosUsuario(usuarioActual.NombreUsuario);

                MessageBox.Show("Datos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            if (!ValidacionCampos.EstanLlenos(txtNuevaContraseña, txtConfirmarContraseña))
            {
                MessageBox.Show("Rellene todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidacionContraseña.SonContraseñasIguales(txtNuevaContraseña.Text, txtConfirmarContraseña.Text))
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            if (ValidacionContraseña.SonContraseñasIguales(txtNuevaContraseña.Text, usuarioActual.Contraseña))
            {
                MessageBox.Show("La nueva contraseña no puede ser igual a la contraseña actual.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNuevaContraseña.Focus();
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Está seguro que desea cambiar su contraseña?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado != DialogResult.Yes)
                return;

            bool actualizado = usuarioLogica.ActualizarUsuario(
                usuarioActual.Id,
                usuarioActual.NombreUsuario ,
                txtNuevaContraseña.Text
            );

            if (actualizado)
            {
                usuarioActual.Contraseña = txtNuevaContraseña.Text;
                MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario.LimpiarCampos(txtNuevaContraseña, txtConfirmarContraseña);
                txtContraseña.Text = usuarioActual.Contraseña;
            }
            else
            {
                MessageBox.Show("No se pudo cambiar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
