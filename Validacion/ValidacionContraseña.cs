public static class ValidacionContraseña
{
    public static bool EsLongitudValida(string contraseña)
    {
        return !string.IsNullOrWhiteSpace(contraseña) && contraseña.Trim().Length >= 5;
    }

    public static bool SonContraseñasIguales(string contraseña, string confirmar)
    {
        return contraseña.Trim() == confirmar.Trim();
    }
}