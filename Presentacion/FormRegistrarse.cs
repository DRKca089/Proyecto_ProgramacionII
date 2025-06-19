using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormRegistrarse : Form
    {

        private UsuarioLogica usuarioLogica = new UsuarioLogica();
        public FormRegistrarse()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string nombre = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text;
            string rol = cmbRol.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contraseña) || string.IsNullOrWhiteSpace(rol))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Validar cliente
            bool valido = usuarioLogica.ValidarUsuario(nombre, contraseña, rol);

            if (valido)
            {
                MessageBox.Show("¡Login exitoso!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                if (rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase) ||
                    rol.Equals("Cliente", StringComparison.OrdinalIgnoreCase))
                {
                    frmMenu menu = new frmMenu(nombre, rol);
                    menu.ShowDialog();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario, contraseña o rol incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
