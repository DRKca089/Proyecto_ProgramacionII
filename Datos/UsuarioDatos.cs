using System;
using System.Collections.Generic;
using System.Linq;

namespace Datos
{
    public class UsuarioDatos
    {
        private static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario { Id = "I0001", NombreUsuario = "Pepe", Contraseña = "1029", RolUsuario = "Administrador", Saldo = 0.00m },
        };

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            usuarios.Add(nuevoUsuario);
        }

        public bool ExisteUsuario(string nombreUsuario)
        {
            return usuarios.Any(u => u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
        }

        public Usuario ObtenerPorNombre(string nombre)
        {
            return usuarios.FirstOrDefault(u => u.NombreUsuario.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public Usuario ObtenerPorId(string id)
        {
            return usuarios.FirstOrDefault(u => u.Id.Equals(id));
        }

        public void ActualizarUsuario(Usuario usuarioActualizado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == usuarioActualizado.Id);
            if (usuario != null)
            {
                usuario.NombreUsuario = usuarioActualizado.NombreUsuario;
                usuario.Contraseña = usuarioActualizado.Contraseña;
                usuario.RolUsuario = usuarioActualizado.RolUsuario;
                usuario.Saldo = usuarioActualizado.Saldo;
            }
        }

        public void EliminarUsuario(string id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
                usuarios.Remove(usuario);
        }

        public List<Usuario> BuscarPorNombreUsuario(string nombreUsuario)
        {
            return usuarios.FindAll(u => u.NombreUsuario.IndexOf(nombreUsuario, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}