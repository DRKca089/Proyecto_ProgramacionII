using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Forms
{
    public partial class frmRegistro : Form
    {
        private UsuarioLogica usuarioLogica = new UsuarioLogica();
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            if (!ValidacionCampos.EstanLlenos(txtUsuario,txtCorreo ,txtContraseña, txtConfirmarContraseña))
                return;

            if (!ValidacionDatos.EsGmail(txtCorreo.Text))
            {
                txtCorreo.Focus();
                return;
            }

            if (!ValidacionContraseña.SonContraseñasIguales(txtContraseña.Text, txtConfirmarContraseña.Text))
            {
                txtConfirmarContraseña.Focus(); //No continua sin son diferentes
                return; 
            }

            string resultadoValidacion = usuarioLogica.ValidarRegistro(txtUsuario.Text, txtCorreo.Text);

            if (resultadoValidacion != "OK")
            {
                MessageBox.Show(resultadoValidacion, "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Envia los datos necesarios a negocio para crear el usuario y agregarlo
            string resultadoRegistro = usuarioLogica.RegistrarUsuario(txtUsuario.Text,txtCorreo.Text, txtContraseña.Text);

            if (resultadoRegistro == "OK")
            {
                MessageBox.Show("Registro exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(resultadoRegistro, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
