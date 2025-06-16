using System.Collections.Generic;
using System.Linq;

public class UsuarioLogica
{
    private List<Usuario> usuarios;

    public UsuarioLogica()
    {
        usuarios = new List<Usuario>
    {
        new Usuario { UsuarioNombre = "Pepe", Contraseña = "1029", Rol = "Administrador" },
        new Usuario { UsuarioNombre = "Juan", Contraseña = "1039", Rol = "Cliente" }
    };
    }
    public bool ValidarUsuario(string nombre, string contraseña, string rol)
    {
        return usuarios.Any(usuario => usuario.UsuarioNombre == nombre
                                && usuario.Contraseña == contraseña
                                && usuario.Rol == rol);
    }
}
