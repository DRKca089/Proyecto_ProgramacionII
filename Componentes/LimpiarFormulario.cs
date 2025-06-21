using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class LimpiarFormulario
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