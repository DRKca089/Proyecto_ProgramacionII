using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ValidacionCorreo
{
    public static bool EsGmail(string correo)
    {
        if (!correo.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            return false;

        int indiceArroba = correo.IndexOf('@');
        if (indiceArroba <= 0)
            return false;

        return true;
    }
}