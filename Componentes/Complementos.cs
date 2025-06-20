using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class ValidadorCampos
{
    //Metodo para ver que los campos esten llenos
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

    //Metodo para ver que el campo tenga formato entero
    public static bool EsEntero(string texto, out int valor, string nombreCampo)
    {
        if (!int.TryParse(texto, out valor))
        {
            MessageBox.Show($"El campo '{nombreCampo}' debe ser un número entero válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    //Metodo para ver que el campo tenga decimal valido
    public static bool EsDecimal(string texto, out decimal valor, string nombreCampo)
    {
        if (!decimal.TryParse(texto, out valor))
        {
            MessageBox.Show($"El campo '{nombreCampo}' debe ser un número decimal válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }
}

public static class UtilidadesFormulario
{
    public static void LimpiarCampos(params Control[] controles)
    {
        foreach (var control in controles)
        {
            if (control is TextBox tb)
            {
                tb.Clear();
            }
        }
    }
}