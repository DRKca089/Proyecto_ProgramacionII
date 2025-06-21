using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class ValidacionContraseña
{
    public static bool SonContraseñasIguales(string contraseña, string confirmar)
    {
        return contraseña.Trim() == confirmar.Trim();
    }
}