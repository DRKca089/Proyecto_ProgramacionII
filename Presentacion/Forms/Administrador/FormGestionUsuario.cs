using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Forms.FormsAdministrador
{
    public partial class frmGestionUsuario : Form
    {
        private UsuarioLogica usuarioLogica = new UsuarioLogica();
        private Usuario usuarioActual;

        public frmGestionUsuario(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            ActualizarTablaUsuarios();
        }

        private void ActualizarTablaUsuarios()
        {
            dGVUsuarios.AutoGenerateColumns = false;
            dGVUsuarios.DataSource = null;
            var usuarios = usuarioLogica.ObtenerTodos();
            dGVUsuarios.DataSource = usuarios;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!CamposValidosParaAgregarModificar(out string mensaje))
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string resultado = usuarioLogica.CrearUsuarioDesdeGestion(txtUsuario.Text.Trim(), txtContraseña.Text, cmbRol.Text.Trim());

            if (resultado == "OK")
            {
                MessageBox.Show("Usuario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaUsuarios();
                LimpiarFormulario.LimpiarCampos(txtID, txtUsuario, txtSaldo, cmbRol, txtContraseña);
            }
            else
            {
                MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!CamposValidosParaAgregarModificar(out string mensaje))
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var usuarioExistente = usuarioLogica.ObtenerUsuario(txtUsuario.Text.Trim());
            if (usuarioExistente != null && usuarioExistente.Id != txtID.Text)
            {
                MessageBox.Show("Ya existe un usuario con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool exito = usuarioLogica.ModificarUsuario(txtID.Text, txtUsuario.Text.Trim(), txtContraseña.Text, cmbRol.Text.Trim());

            if (exito)
            {
                MessageBox.Show("Usuario modificado correctamente.");
                ActualizarTablaUsuarios();
                LimpiarFormulario.LimpiarCampos(txtID, txtUsuario, txtSaldo, cmbRol, txtContraseña);
            }
            else
            {
                MessageBox.Show("Error al modificar usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!ValidacionCampos.EstanLlenos(txtID, txtUsuario, txtContraseña, txtSaldo))
            {
                MessageBox.Show("Rellene todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dGVUsuarios.CurrentRow == null || usuarioActual == null)
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idAEliminar = dGVUsuarios.CurrentRow.Cells["ID"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(idAEliminar))
            {
                MessageBox.Show("No se pudo obtener el ID del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("¿Seguro que desea eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool exito = usuarioLogica.EliminarUsuario(idAEliminar, usuarioActual.Id);
                if (exito)
                {
                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarTablaUsuarios();
                    LimpiarFormulario.LimpiarCampos(txtID, txtUsuario, txtSaldo, cmbRol, txtContraseña);
                }
                else
                {
                    string msg = idAEliminar == usuarioActual.Id ? "No puedes eliminarte a ti mismo." : "No se pudo eliminar el usuario.";
                    MessageBox.Show(msg, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dGVUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dGVUsuarios.Rows.Count)
                {
                    DataGridViewRow fila = dGVUsuarios.Rows[e.RowIndex];

                    txtID.Text = fila.Cells[0]?.Value?.ToString() ?? "";
                    cmbRol.Text = fila.Cells[1]?.Value?.ToString() ?? "";
                    txtUsuario.Text = fila.Cells[2]?.Value?.ToString() ?? "";
                    txtContraseña.Text = fila.Cells[3]?.Value?.ToString() ?? "";

                    if (decimal.TryParse(fila.Cells[4]?.Value?.ToString(), out decimal saldo))
                    {
                        txtSaldo.Text = string.Format("{0:C2}", saldo);
                    }
                    else
                    {
                        txtSaldo.Text = "$0.00";
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show($"Se intentó acceder a una fila que no existe.\n{ ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al seleccionar el usuario.\n {ex.Message}\n Porfavor comunicarse con atención al cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            // Validación si está vacío
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                MessageBox.Show("Por favor ingrese un nombre de usuario para buscar.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar usuarios por nombre (que contengan el texto)
            List<Usuario> usuariosPorNombre = usuarioLogica.BuscarPorNombre(busqueda);

            if (usuariosPorNombre.Any())
            {
                dGVUsuarios.DataSource = usuariosPorNombre;
            }
            else
            {
                MessageBox.Show("No se encontraron usuarios con ese nombre.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Restaurar tabla y limpiar campo
                txtBuscar.Clear();
                ActualizarTablaUsuarios();

            }
        }

        private bool CamposValidosParaAgregarModificar(out string mensaje)
        {
            mensaje = "";

            if (!ValidacionCampos.EstanLlenos(txtUsuario, txtContraseña, cmbRol))
            {
                mensaje = "Rellene todos los campos.";
                return false;
            }

            if (!ValidacionContraseña.EsLongitudValida(txtContraseña.Text))
            {
                mensaje = "La contraseña debe tener al menos 5 caracteres.";
                return false;
            }

            return true;
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar.PerformClick(); 
            }
        }
    }
}