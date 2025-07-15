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
            txtUsuario.Text = usuarioActual.Nombre;
            txtContraseña.Text = usuarioActual.Contraseña;
            txtSaldo.Text = usuarioActual.Saldo.ToString("C2");
        }

        private void Restricciones()
        {
            bool esAdmin = usuarioActual.Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
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
            // Validar si quiere cambiar el nombre
            string validacion = usuarioLogica.ValidarRegistro(txtUsuario.Text);
            bool nombreCambió = !txtUsuario.Text.Equals(usuarioActual.Nombre, StringComparison.OrdinalIgnoreCase);

            if (!ValidacionCampos.EstanLlenos(txtUsuario)){
                MessageBox.Show("El nombre de usuario no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (validacion != "OK" && nombreCambió && validacion.Contains("usuario"))
            {
                MessageBox.Show(validacion, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar si quiere cambiar contraseña
            bool cambiarContraseña = !string.IsNullOrWhiteSpace(txtNuevaContraseña.Text) || !string.IsNullOrWhiteSpace(txtConfirmarContraseña.Text);

            if (!nombreCambió && !cambiarContraseña)
            {
                MessageBox.Show("Debe modificar al menos el nombre de usuario o la contraseña para guardar los cambios.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cambiarContraseña)
            {
                if (!ValidacionCampos.EstanLlenos(txtNuevaContraseña, txtConfirmarContraseña))
                {
                    MessageBox.Show("Rellene ambos campos de contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidacionContraseña.EsLongitudValida(txtNuevaContraseña.Text))
                {
                    MessageBox.Show("La nueva contraseña debe tener al menos 5 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidacionContraseña.SonContraseñasIguales(txtNuevaContraseña.Text, txtConfirmarContraseña.Text))
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                    return;
                }

                if (ValidacionContraseña.SonContraseñasIguales(txtNuevaContraseña.Text, usuarioActual.Contraseña))
                {
                    MessageBox.Show("La nueva contraseña no puede ser igual a la actual.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNuevaContraseña.Focus();
                    return;
                }

                DialogResult resultado = MessageBox.Show("¿Está seguro que desea cambiar su contraseña?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                    return;
            }

            string nuevaContraseña = cambiarContraseña ? txtNuevaContraseña.Text.Trim() : usuarioActual.Contraseña;

            bool actualizado = usuarioLogica.ModificarUsuario(usuarioActual.Id, txtUsuario.Text, nuevaContraseña);

            if (actualizado)
            {
                if (nombreCambió)
                {
                    usuarioActual.Nombre = txtUsuario.Text;
                    formularioPadre.RefrescarDatosUsuario(usuarioActual.Nombre);
                }
                if (cambiarContraseña)
                {
                    usuarioActual.Contraseña = txtNuevaContraseña.Text;
                    LimpiarFormulario.LimpiarCampos(txtNuevaContraseña, txtConfirmarContraseña);
                    txtContraseña.Text = usuarioActual.Contraseña;
                }
                MessageBox.Show("Datos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnDepositar.PerformClick();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnGuardarCambios.PerformClick();
            }
        }
    }
}
