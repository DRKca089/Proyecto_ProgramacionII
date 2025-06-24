public static class ValidacionContraseña
{
    public static bool SonContraseñasIguales(string contraseña, string confirmar)
    {
        return contraseña.Trim() == confirmar.Trim();
    }
}