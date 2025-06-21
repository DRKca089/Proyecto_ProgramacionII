using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class UsuarioDatos
    {
        private static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario { Id = "I0001", UsuarioNombre = "Pepe", Contraseña = "1029", Rol = "Administrador", Correo = "pepe@gmail.com", Saldo = 0.00m },
            new Usuario { Id = "I0002", UsuarioNombre = "Juan", Contraseña = "1039", Rol = "Cliente", Correo = "juan@gmail.com", Saldo = 0.00m }
        };

        // Obtener lista completa de usuarios
        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        // Agregar usuario sin validar (asume que ya se validó en negocio)
        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            usuarios.Add(nuevoUsuario);
        }

        // Verificar si existe un usuario por nombre
        public bool ExisteUsuario(string nombreUsuario)
        {
            return usuarios.Any(u => u.UsuarioNombre.Equals(nombreUsuario, System.StringComparison.OrdinalIgnoreCase));
        }

        public Usuario ObtenerPorNombre(string nombre)
        {
            return usuarios.FirstOrDefault(u => u.UsuarioNombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public Usuario ObtenerPorId(string id)
        {
            return usuarios.FirstOrDefault(u => u.Id.Equals(id));
        }
        public bool ExisteCorreo(string correo)
        {
            return usuarios.Any(u => u.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase));
        }

        public void ActualizarUsuario(Usuario usuarioActualizado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == usuarioActualizado.Id);
            if (usuario != null)
            {
                usuario.UsuarioNombre = usuarioActualizado.UsuarioNombre;
                usuario.Contraseña = usuarioActualizado.Contraseña;
                usuario.Rol = usuarioActualizado.Rol;
                usuario.Correo = usuarioActualizado.Correo;
                usuario.Saldo = usuarioActualizado.Saldo;
            }
        }
    }
}
