using System;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class FormProducto : Form
    {
        private ProductoLogica productoLogica = new ProductoLogica();
        public FormProducto()
        {
            InitializeComponent();
        }

        private void ActualizarTablaProducto()
        {
            dGVProducto.AutoGenerateColumns = false;
            dGVProducto.DataSource = null;
            dGVProducto.DataSource = productoLogica.ListarProductos();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string nombre = txtProductoNombre.Text.Trim();
            string cantidadTexto = txtProductoCantidad.Text.Trim();
            string valorTexto = txtProductoValor.Text.Trim();
            //Válida que los campos no esten vacios
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(cantidadTexto) || string.IsNullOrWhiteSpace(valorTexto))
            {
                MessageBox.Show("Por favor, rellene todos los campos.", "Formulario incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Válida que el formato sea el correcto del valor
            if (!int.TryParse(cantidadTexto, out int cantidad))
            {
                MessageBox.Show("La cantidad debe ser un número entero válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Válida que el formato sea el correcto del valor
            if (!decimal.TryParse(valorTexto, out decimal valor))
            {
                MessageBox.Show("El valor debe ser un número decimal válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Producto nuevoProducto = new Producto
            {
                Nombre = nombre,
                CantidadDisponible = cantidad,
                Valor = valor
            };

            try
            {
                productoLogica.Agregar(nuevoProducto);
                MessageBox.Show("Producto agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaProducto();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductoCodigo.Text))
            {
                MessageBox.Show("Selecciona un producto para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro que desea modificar el producto?", 
                "Confirmar modificación", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                try
                {
                    Producto productoModificado = new Producto
                    {
                        Codigo = txtProductoCodigo.Text,
                        Nombre = txtProductoNombre.Text,
                        CantidadDisponible = int.Parse(txtProductoCantidad.Text),
                        Valor = decimal.Parse(txtProductoValor.Text)
                    };

                    productoLogica.Modificar(productoModificado);

                    MessageBox.Show("Producto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ActualizarTablaProducto();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductoCodigo.Text))
            {
                MessageBox.Show("Selecciona un producto para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar este producto?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    string codigo = txtProductoCodigo.Text;
                    productoLogica.Eliminar(codigo);

                    MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarTablaProducto();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dGVProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Evita que se seleccione el encabezado
            {
                DataGridViewRow fila = dGVProducto.Rows[e.RowIndex];

                txtProductoCodigo.Text = fila.Cells[0].Value.ToString();
                txtProductoNombre.Text = fila.Cells[1].Value.ToString();
                txtProductoCantidad.Text = fila.Cells[2].Value.ToString();
                txtProductoValor.Text = fila.Cells[3].Value.ToString();
            }
        }
        private void LimpiarCampos()
        {
            txtProductoCodigo.Clear();
            txtProductoNombre.Clear();
            txtProductoCantidad.Clear();
            txtProductoValor.Clear();
        }
    }
}
