using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Forms.FormsAdministrador
{
    public partial class frmGestionUsuario : Form
    {
        private UsuarioLogica usuarioLogica = new UsuarioLogica();
        public frmGestionUsuario()
        {
            InitializeComponent();
            ActualizarTablaUsuarios();
        }

        private void ActualizarTablaUsuarios()
        {
            dGVUsuarios.AutoGenerateColumns = false;
            dGVUsuarios.DataSource = null;
            var usuarios = usuarioLogica.ObtenerTodos();
            dGVUsuarios.DataSource = usuarios;

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string usuarioNombre = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text;
            string rol = cmbRol.Text.Trim();

            string resultado = usuarioLogica.CrearUsuarioDesdeGestion(usuarioNombre, contraseña, rol);

            if (resultado == "OK")
            {
                MessageBox.Show("Usuario agregado correctamente.");
                ActualizarTablaUsuarios();
                LimpiarFormulario.LimpiarCampos(txtID, txtUsuario, txtSaldo, cmbRol, txtContraseña);

            }
            else
            {
                MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Seleccione un usuario para modificar.");
                return;
            }

            string nuevoNombre = txtUsuario.Text.Trim();
            string nuevaContraseña = txtContraseña.Text;
            string nuevoRol = cmbRol.Text.Trim();

            bool exito = usuarioLogica.ActualizarUsuario(id, nuevoNombre, nuevaContraseña, nuevoRol);


            if (exito)
            {
                MessageBox.Show("Usuario modificado correctamente.");
                ActualizarTablaUsuarios();
                LimpiarFormulario.LimpiarCampos(txtID, txtUsuario, txtSaldo, cmbRol, txtContraseña);
            }
            else
            {
                MessageBox.Show("Error al modificar usuario.");
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Seleccione un usuario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("¿Seguro que desea eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                bool exito = usuarioLogica.EliminarUsuario(id);

                if (exito)
                {
                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarTablaUsuarios();
                    LimpiarFormulario.LimpiarCampos(txtID, txtUsuario, txtSaldo, cmbRol, txtContraseña);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Se intentó acceder a una fila que no existe.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al seleccionar el usuario.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text.Trim();

            // Si el campo está vacío, recarga toda la tabla
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                ActualizarTablaUsuarios();
                return;
            }

            // Buscar usuarios por nombre (que contengan el texto)
            List<Usuario> usuariosPorNombre = usuarioLogica.BuscarUsuariosPorNombre(busqueda);
            if (usuariosPorNombre.Any())
            {
                dGVUsuarios.DataSource = usuariosPorNombre;
            }
            else
            {
                MessageBox.Show("No se encontraron usuarios.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dGVUsuarios.DataSource = null;
            }
        }
    }
}
