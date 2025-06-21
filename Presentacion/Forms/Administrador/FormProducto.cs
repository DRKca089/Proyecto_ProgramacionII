using System;
using Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class frmProducto : Form
    {
        private ProductoLogica productoLogica;
        public frmProducto(ProductoLogica logica)
        {
            InitializeComponent();
            productoLogica = logica;
            ActualizarTablaProducto();
        }

        private void ActualizarTablaProducto()
        {
            dGVProducto.AutoGenerateColumns = false;
            dGVProducto.DataSource = null;
            dGVProducto.DataSource = productoLogica.ListarProductos();
        }


        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidacionCampos.EstanLlenos(txtProductoNombre, txtProductoCantidad, txtProductoValor))
            {
                MessageBox.Show("Rellene todos los campos");
                return;
            }

            if (!ValidacionNumeros.EsEntero(txtProductoCantidad.Text.Trim(), out int cantidad))
            {
                MessageBox.Show("La cantidad debe ser un valor entero");
                return;
            }

            if (!ValidacionNumeros.EsDecimal(txtProductoValor.Text.Trim(), out decimal valor))
            {
                MessageBox.Show("El valor debe ser un valor decimal con dos decimas");
                return;
            }

            Producto nuevoProducto = new Producto
            {
                Nombre = txtProductoNombre.Text,
                CantidadDisponible = cantidad,
                Valor = valor
            };

            try
            {
                productoLogica.Agregar(nuevoProducto);
                MessageBox.Show("Producto agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarTablaProducto();
                LimpiarFormulario.LimpiarCampos(txtProductoCodigo, txtProductoNombre, txtProductoCantidad, txtProductoValor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidacionCampos.EstanLlenos(txtProductoCodigo, txtProductoNombre, txtProductoCantidad, txtProductoValor))
            {
                MessageBox.Show("Rellene todos los campos");
                return;
            }

            if (!ValidacionNumeros.EsEntero(txtProductoCantidad.Text.Trim(), out int cantidad))
            {
                MessageBox.Show("La cantidad debe ser un valor entero");
                return;
            }

            if (!ValidacionNumeros.EsDecimal(txtProductoValor.Text.Trim(), out decimal valor))
            {
                MessageBox.Show("El valor debe ser un valor decimal con dos decimas");
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
                        CantidadDisponible = cantidad,
                        Valor = valor
                    };

                    productoLogica.Modificar(productoModificado);
                    MessageBox.Show("Producto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarTablaProducto();
                    LimpiarFormulario.LimpiarCampos(txtProductoCodigo, txtProductoNombre, txtProductoCantidad, txtProductoValor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidacionCampos.EstanLlenos(txtProductoCodigo, txtProductoNombre, txtProductoCantidad, txtProductoValor))
            {
                MessageBox.Show("Rellene todos los campos");
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
                    string codigo = txtProductoCodigo.Text.Trim();
                    productoLogica.Eliminar(codigo);

                    MessageBox.Show("Producto eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarTablaProducto();
                    LimpiarFormulario.LimpiarCampos(txtProductoCodigo, txtProductoNombre, txtProductoCantidad, txtProductoValor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidacionCampos.EstanLlenos(txtProductoBuscar))
            {
                ActualizarTablaProducto();
                return;
            }

            // Buscar por código
            Producto productoPorCodigo = productoLogica.BuscarPorCodigo(txtProductoBuscar.Text);
            if (productoPorCodigo != null)
            {
                dGVProducto.DataSource = new List<Producto> { productoPorCodigo };
                return;
            }

            // Buscar por nombre
            List<Producto> productosPorNombre = productoLogica.BuscarPorNombre(txtProductoBuscar.Text);
            if (productosPorNombre.Any())
            {
                dGVProducto.DataSource = productosPorNombre;
            }
            else
            {
                MessageBox.Show("No se encontraron productos.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dGVProducto.DataSource = null;
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
    }
}
