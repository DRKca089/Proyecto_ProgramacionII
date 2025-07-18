using System;

public static class ValidacionUsuario
{
    public static bool EsRolValido(string rol)
    {
        return rol.Equals("Cliente", StringComparison.OrdinalIgnoreCase) ||
               rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
    }

    public static string VerificarExistencia(string nombre, UsuarioDatos datos)
    {
        if (datos.ExisteUsuario(nombre))
            return "El nombre de usuario ya está en uso.";
        return "OK";
    }
}