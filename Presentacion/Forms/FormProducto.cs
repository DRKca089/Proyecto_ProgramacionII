using System;
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
            if (string.IsNullOrWhiteSpace(txtProductoNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtProductoCantidad.Text) ||
                    string.IsNullOrWhiteSpace(txtProductoValor.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string valorTexto = txtProductoValor.Text.Trim();
            string cantidadTexto = txtProductoCantidad.Text.Trim();

            if (!decimal.TryParse(valorTexto, out decimal valorDecimal))
            {
                MessageBox.Show("Valor no válido. Ingresa un número correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cantidadTexto, out int valorInt))
            {
                MessageBox.Show("Cantidad no valida. Ingrese un número correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal valorMultiplicado = valorDecimal * 100;
            if (valorMultiplicado != Math.Floor(valorMultiplicado))
            {
                MessageBox.Show("Solo se permiten hasta 2 decimales.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codigoGenerado = productoLogica.GenerarCodigo();
            txtProductoCodigo.Text = codigoGenerado;



            Producto nuevoProducto = new Producto
            {
                Codigo = codigoGenerado,
                Nombre = txtProductoNombre.Text.Trim(),
                CantidadDisponible = int.Parse(txtProductoCantidad.Text),
                Valor = valorDecimal
            };

            try
            {
                productoLogica.Agregar(nuevoProducto);
                MessageBox.Show("Producto agregado correctamente");
                ActualizarTablaProducto();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
