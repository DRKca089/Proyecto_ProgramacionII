using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms.FormsCliente
{
    public partial class frmEditarUsuario : Form
    {
        private Usuario usuarioActual;
        private UsuarioLogica usuarioLogica = new UsuarioLogica();
        private UsuarioDatos usuarioDato = new UsuarioDatos();
        public frmEditarUsuario(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            MostrarDatos();
            Restricciones();
        }

        private void MostrarDatos()
        {
            txtID.Text = usuarioActual.Id;
            txtUsuario.Text = usuarioActual.UsuarioNombre;
            txtCorreo.Text = usuarioActual.Correo;
            txtContraseña.Text = usuarioActual.Contraseña;
            txtSaldo.Text = usuarioActual.Saldo.ToString("C2");
        }

        private void Restricciones()
        {
            if (usuarioActual.Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                txtMonto.Enabled = false;
                btnDepositar.Enabled = false;
            }
            else
            {
                txtMonto.Enabled = true;
                btnDepositar.Enabled = true;
            }
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            if (!ValidacionDatos.EsDecimal(txtMonto.Text.Trim(), out decimal monto, "Monto"))
            {
                txtMonto.Focus();
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
            if (!ValidacionCampos.EstanLlenos(txtUsuario, txtCorreo))
                return;

            if (!ValidacionDatos.EsGmail(txtCorreo.Text))
            {
                txtCorreo.Focus();
                return;
            }

            if (!txtUsuario.Text.Equals(usuarioActual.UsuarioNombre, StringComparison.OrdinalIgnoreCase) &&
                usuarioDato.ExisteUsuario(txtUsuario.Text))
            {
                MessageBox.Show("El nombre de usuario ya está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }

            if (!txtCorreo.Text.Equals(usuarioActual.Correo, StringComparison.OrdinalIgnoreCase) &&
                usuarioDato.ExisteCorreo(txtCorreo.Text))
            {
                MessageBox.Show("El correo electrónico ya está en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            string nuevaContraseña = usuarioActual.Contraseña;



            if (ValidacionCampos.EstanLlenos(txtContraseña, txtNuevaContraseña, txtConfirmarContraseña))
            {
                if (!ValidacionContraseña.SonContraseñasIguales(txtContraseña.Text, usuarioActual.Contraseña))
                {
                    txtContraseña.Focus();
                    return;
                }

                if (!ValidacionContraseña.SonContraseñasIguales(txtNuevaContraseña.Text, txtConfirmarContraseña.Text))
                {
                    txtConfirmarContraseña.Focus();
                    return;
                }

                nuevaContraseña = txtNuevaContraseña.Text;
            }

            // Actualizar usuario en la lógica de negocio
            bool actualizado = usuarioLogica.ActualizarUsuario(usuarioActual.Id, txtUsuario.Text, txtCorreo.Text, nuevaContraseña);

            if (actualizado)
            {
                usuarioActual.UsuarioNombre = txtUsuario.Text;
                usuarioActual.Correo = txtCorreo.Text;
                usuarioActual.Contraseña = nuevaContraseña;

                MessageBox.Show("Datos actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario.LimpiarCampos(txtContraseña, txtNuevaContraseña, txtConfirmarContraseña);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
