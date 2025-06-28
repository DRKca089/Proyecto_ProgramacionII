using Negocio;
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
                int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);

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
            List<ProductoCompra> carrito = productoLogica.ObtenerProductosParaCompra(productos, cantidadesSeleccionadas);

            frmCompra frmcompra = new frmCompra(carrito, usuarioActual);
            var resultado = frmcompra.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                // Solo cuando el usuario confirme la compra, actualizar el stock
                productoLogica.ActualizarStock(cantidadesSeleccionadas);
                cantidadesSeleccionadas.Clear(); // ✅ Limpia solo si se confirma
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
            if (!ValidacionCampos.EstanLlenos(txtBuscar))
            {
                ActualizarTabla();
                return;
            }

            // Buscar por código
            Producto productoPorCodigo = productoLogica.BuscarPorCodigo(txtBuscar.Text);
            if (productoPorCodigo != null)
            {
                dGVTienda.DataSource = new List<Producto> { productoPorCodigo };
                return;
            }

            // Buscar por nombre
            List<Producto> productosPorNombre = productoLogica.BuscarPorNombre(txtBuscar.Text);
            if (productosPorNombre.Any())
            {
                dGVTienda.DataSource = productosPorNombre;
            }
            else
            {
                MessageBox.Show("No se encontraron productos.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dGVTienda.DataSource = null;
            }

            // Al cerrar EditarUsuario y volver a abrir Tienda
            frmTienda tienda = new frmTienda(usuarioActual, cantidadesSeleccionadas);
            tienda.Show();
        }
    }
}
