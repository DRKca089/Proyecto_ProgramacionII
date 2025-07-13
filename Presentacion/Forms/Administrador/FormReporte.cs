using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Negocio;

namespace Presentacion.Forms
{
    public partial class FormReporte : Form
    {
        private ProductoLogica productoLogica = new ProductoLogica();
        private CompraLogica compralogica = new CompraLogica();

        public FormReporte()
        {
            InitializeComponent();
            dGVReporte.AutoGenerateColumns = false;
            lblTotal.Text = $"${compralogica.ObtenerIngresoTotalVentas():F2}";
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
            if (!ValidacionCampos.EstanLlenos(txtNumeroProductos, cmbTipoReporte))
            {
                MessageBox.Show("Por favor rellene todos los campos.");
                return;
            }


            if (!ValidacionNumeros.EsEntero(txtNumeroProductos.Text.Trim(), out int numeroProductos) || numeroProductos < 1)
            {
                MessageBox.Show("Ingresa un número positivo valido.");
                return;
            }

            string tipoReporte = cmbTipoReporte.SelectedItem?.ToString()?.Trim();
            List<object> reporte = new List<object>();

            try
            {
                switch (tipoReporte)
                {
                    case "Productos más vendidos":
                        var mas = productoLogica.ObtenerProductosMasVendidos(numeroProductos);
                        dGVReporte.DataSource = null;
                        dGVReporte.DataSource = mas;
                        dGVReporte.Columns["Stock"].Visible = false;
                        dGVReporte.Columns["CantidadVendida"].Visible = true;
                        dGVReporte.Columns["Ingreso"].Visible = true;
                        break;

                    case "Productos menos vendidos":
                        var menos = productoLogica.ObtenerProductosMenosVendidos(numeroProductos);
                        dGVReporte.DataSource = null;
                        dGVReporte.DataSource = menos;
                        dGVReporte.Columns["Stock"].Visible = false;
                        dGVReporte.Columns["CantidadVendida"].Visible = true;
                        dGVReporte.Columns["Ingreso"].Visible = true;
                        break;

                    case "Stock Bajo":
                        var bajo = productoLogica.ObtenerProductosConMenorStock(numeroProductos);
                        dGVReporte.DataSource = null;
                        dGVReporte.DataSource = bajo;
                        dGVReporte.Columns["Stock"].Visible = true;
                        dGVReporte.Columns["CantidadVendida"].Visible = false;
                        dGVReporte.Columns["Ingreso"].Visible = false;
                        break;

                    default:
                        MessageBox.Show("Tipo de reporte no reconocido.");
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}");
            }
        }
    }
}