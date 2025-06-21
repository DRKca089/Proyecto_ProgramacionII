using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class ValidacionNumeros
{
    public static bool EsEntero(string texto, out int valor )
    {
        return int.TryParse(texto, out valor);
    }

    public static bool EsDecimal(string texto, out decimal valor)
    {
        return decimal.TryParse(texto, out valor);
    }
}
