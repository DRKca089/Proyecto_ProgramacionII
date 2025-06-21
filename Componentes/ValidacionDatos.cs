using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class ValidacionDatos
{
    public static bool EsEntero(string texto, out int valor, string nombreCampo)
    {
        if (!int.TryParse(texto, out valor))
        {
            MessageBox.Show($"El campo '{nombreCampo}' debe ser un número entero válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    public static bool EsDecimal(string texto, out decimal valor, string nombreCampo)
    {
        if (!decimal.TryParse(texto, out valor))
        {
            MessageBox.Show($"El campo '{nombreCampo}' debe ser un número decimal válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    public static bool EsGmail(string correo)
    {
        if (!correo.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("El correo debe terminar en '@gmail.com'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        int indiceArroba = correo.IndexOf('@');

        if (indiceArroba <= 0)
        {
            MessageBox.Show("Debe ingresar un nombre de usuario antes de '@gmail.com'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }
}