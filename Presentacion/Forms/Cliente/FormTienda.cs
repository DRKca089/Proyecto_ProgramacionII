using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Presentacion.Forms.FormsCliente
{
    public partial class frmTienda : Form
    {
        private ProductoLogica productoLogica = new ProductoLogica();
        private Dictionary<string, int> cantidadesSeleccionadas;
        private Usuario usuarioActual;

        public frmTienda(Usuario usuario, Dictionary<string, int> cantidadesGuardadas = null)
        {
            InitializeComponent();
            usuarioActual = usuario;
            cantidadesSeleccionadas = cantidadesGuardadas ?? new Dictionary<string, int>();
            this.Shown += frmTienda_Shown;
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            cantidadesSeleccionadas.Clear();

            foreach (DataGridViewRow fila in dGVTienda.Rows)
            {
                string codigo = fila.Cells["Codigo"].Value?.ToString();
                int cantidad = 0;

                if (fila.Cells["Cantidad"].Value != null)
                    int.TryParse(fila.Cells["Cantidad"].Value.ToString(), out cantidad);

                if (!string.IsNullOrEmpty(codigo) && cantidad > 0)
                {
                    cantidadesSeleccionadas[codigo] = cantidad;
                }
            }

            if (cantidadesSeleccionadas.Count == 0)
            {
                MessageBox.Show("No hay productos seleccionados para comprar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Producto> productos = productoLogica.ListarProductos();
            List<CompraDetalles> carrito = productoLogica.ObtenerProductosParaCompra(productos, cantidadesSeleccionadas);

            frmCompra frmcompra = new frmCompra(carrito, usuarioActual);
            var resultado = frmcompra.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                productoLogica.ActualizarStock(cantidadesSeleccionadas);
                cantidadesSeleccionadas.Clear();
                ActualizarTabla();
            }
        }

        private void frmTienda_Load(object sender, EventArgs e)
        {
            dGVTienda.AutoGenerateColumns = false;
            dGVTienda.DataSource = productoLogica.ListarProductos();
        }

        //Rellena el campo cuando la tabla ya se muestra
        private void frmTienda_Shown(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dGVTienda.Rows)
            {
                string codigo = fila.Cells["Codigo"].Value?.ToString();

                if (codigo != null && cantidadesSeleccionadas.TryGetValue(codigo, out int cantidadGuardada))
                {
                    fila.Cells["Cantidad"].Value = cantidadGuardada;
                }
                else
                {
                    fila.Cells["Cantidad"].Value = 0;
                }
            }
        }

        private void dGVTienda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var columna = dGVTienda.Columns[e.ColumnIndex];
                var fila = dGVTienda.Rows[e.RowIndex];
                string codigo = fila.Cells["Codigo"].Value?.ToString();
                int cantidadActual = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                int stockReal = Convert.ToInt32(fila.Cells["Stock"].Tag ?? fila.Cells["Stock"].Value);

                if (columna.Name == "Agregar")
                {
                    if (cantidadActual < stockReal)
                    {
                        cantidadActual++;
                        fila.Cells["Cantidad"].Value = cantidadActual;
                        cantidadesSeleccionadas[codigo] = cantidadActual;
                    }
                }
                else if (columna.Name == "Disminuir")
                {
                    if (cantidadActual > 0)
                    {
                        cantidadActual--;
                        fila.Cells["Cantidad"].Value = cantidadActual;
                        if (cantidadActual == 0)
                            cantidadesSeleccionadas.Remove(codigo);
                        else
                            cantidadesSeleccionadas[codigo] = cantidadActual;
                    }
                }
            }
        }

        private void ActualizarTabla()
        {
            dGVTienda.DataSource = null;
            dGVTienda.DataSource = productoLogica.ListarProductos();

            foreach (DataGridViewRow fila in dGVTienda.Rows)
            {
                string codigo = fila.Cells["Codigo"].Value?.ToString();

                if (codigo != null && cantidadesSeleccionadas.TryGetValue(codigo, out int cantidadGuardada))
                {
                    fila.Cells["Cantidad"].Value = cantidadGuardada;
                }
                else
                {
                    fila.Cells["Cantidad"].Value = 0;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                MessageBox.Show("Por favor escriba el nombre o código del producto que desea buscar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Buscar por código
            Producto productoPorCodigo = productoLogica.BuscarPorCodigo(textoBusqueda);
            if (productoPorCodigo != null)
            {
                dGVTienda.DataSource = new List<Producto> { productoPorCodigo };
                return;
            }

            // Buscar por nombre
            List<Producto> productosPorNombre = productoLogica.BuscarPorNombre(textoBusqueda);
            if (productosPorNombre.Any())
            {
                dGVTienda.DataSource = productosPorNombre;
            }
            else
            {
                MessageBox.Show("Producto no existente.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBuscar.Clear();           // Limpiar campo
                ActualizarTabla();           // Recargar todos los productos
            }
            if (!ValidacionCampos.EstanLlenos(txtBuscar))
            {
                ActualizarTabla();
                return;
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }
    }
}