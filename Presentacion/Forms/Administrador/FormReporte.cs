using System;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class frmReporte : Form
    {
        private ProductoLogica productoLogica = new ProductoLogica();
        private CompraLogica compraLogica = new CompraLogica();

        public frmReporte()
        {
            InitializeComponent();
            dGVReporte.AutoGenerateColumns = false;
        }

        private void CargarReporte(string tipo, int numero)
        {
            try
            {
                object reporteData = null;

                switch (tipo)
                {
                    case "Productos más vendidos":
                        reporteData = productoLogica.ObtenerProductosMasVendidos(numero);
                        ConfigurarColumnas(true, true, false);
                        break;

                    case "Productos menos vendidos":
                        reporteData = productoLogica.ObtenerProductosMenosVendidos(numero);
                        ConfigurarColumnas(true, true, false);
                        break;

                    case "Stock Bajo":
                        reporteData = productoLogica.ObtenerProductosConMenorStock(numero);
                        ConfigurarColumnas(false, false, true);
                        break;

                    default:
                        MessageBox.Show("Tipo de reporte no reconocido.");
                        return;
                }
                dGVReporte.DataSource = null;
                dGVReporte.DataSource = reporteData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}");
            }

        }

        private void ConfigurarColumnas(bool mostrarCantidad, bool mostrarIngreso, bool mostrarStock)
        {
            if (dGVReporte.Columns.Contains("CantidadVendida"))
                dGVReporte.Columns["CantidadVendida"].Visible = mostrarCantidad;

            if (dGVReporte.Columns.Contains("Ingreso"))
                dGVReporte.Columns["Ingreso"].Visible = mostrarIngreso;

            if (dGVReporte.Columns.Contains("Stock"))
                dGVReporte.Columns["Stock"].Visible = mostrarStock;
        }

        private void txtNProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGenerarReporte.PerformClick();
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            string tipoSeleccionado = cmbTipoReporte.SelectedItem?.ToString()?.Trim();

            if (!ValidacionCampos.EstanLlenos(txtNumeroProductos) || !ValidacionCampos.EstanLlenos(cmbTipoReporte))
            {
                MessageBox.Show("Complete todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!int.TryParse(txtNumeroProductos.Text.Trim(), out int numero) || numero < 1)
            {
                MessageBox.Show("Número de productos inválido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Aquí validamos con el total general de productos sin crear métodos nuevos
            int totalProductos = productoLogica.ListarProductos().Count;

            if (numero > totalProductos)
            {
                MessageBox.Show($"Solo existen {totalProductos} productos registrados. Por favor ingrese un número válido.",
                    "Número excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarReporte(tipoSeleccionado, numero);

        }

        private void frmReporte_Load(object sender, EventArgs e)
        {
            lblTotal.Text = $" {compraLogica.ObtenerIngresoTotalVentas():C2}";
        }
    }
}