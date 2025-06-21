using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class ValidacionCampos
{
    public static bool EstanLlenos(params Control[] controles)
    {
        foreach (var control in controles)
        {
            if (control is TextBox t && string.IsNullOrWhiteSpace(t.Text))
            {
                MessageBox.Show("Rellene todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                t.Focus();
                return false;
            }
            else if (control is ComboBox c && string.IsNullOrWhiteSpace(c.Text))
            {
                MessageBox.Show("Seleccione una opción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                c.Focus();
                return false;
            }
        }
        return true;
    }
}
