using System;
using System.Collections.Generic;
using System.Linq;
using Datos;

namespace Negocio
{
    public class UsuarioLogica
    {
        private UsuarioDatos usuarioDatos = new UsuarioDatos();

        private string GenerarNuevoId()
        {
            int siguienteNumero;
            var usuarios = usuarioDatos.ObtenerUsuarios();
            if (usuarios.Any()) // Verifica si hay usuarios registrados
            {
                int numeroMaximo = usuarios
                    .Select(u => int.Parse(u.Id.Substring(1)))
                    .Max();

                siguienteNumero = numeroMaximo + 1;
            }
            else
            {
                siguienteNumero = 1;
            }

            return "I" + siguienteNumero.ToString("D4");
        }

        public string RegistrarUsuario(string nombre, string correo, string contraseña)
        {
            return CrearUsuario(nombre, correo, contraseña, "Cliente");
        }

        public string ValidarInicioSesion(string nombre, string contraseña, string rol)
        {
            var usuario = usuarioDatos.ObtenerPorNombre(nombre);
            if (usuario == null || usuario.Contraseña != contraseña || !usuario.Rol.Equals(rol, StringComparison.OrdinalIgnoreCase))
                return "Usuario, contraseña o rol incorrecto.";

            return "OK";
        }

        public string ValidarRegistro(string nombre, string correo)
        {
            if (usuarioDatos.ExisteUsuario(nombre))
                return "El nombre de usuario ya está en uso.";

            if (usuarioDatos.ExisteCorreo(correo))
                return "El correo electrónico ya está en uso.";

            return "OK";
        }

        public List<Usuario> ObtenerTodos()
        {
            return usuarioDatos.ObtenerUsuarios();
        }

        public Usuario ObtenerUsuario(string nombre)
        {
            return usuarioDatos.ObtenerPorNombre(nombre);
        }

        public bool ActualizarUsuario(string id, string nuevoNombre, string nuevoCorreo, string nuevaContraseña, string nuevoRol = null)
        {
            var usuario = usuarioDatos.ObtenerPorId(id);
            if (usuario == null)
                return false;

            usuario.UsuarioNombre = nuevoNombre;
            usuario.Correo = nuevoCorreo;
            usuario.Contraseña = nuevaContraseña;

            if (nuevoRol != null)
                usuario.Rol = nuevoRol;

            usuarioDatos.ActualizarUsuario(usuario);
            return true;
        }

        public bool EliminarUsuario(string id)
        {
            var usuario = usuarioDatos.ObtenerPorId(id);
            if (usuario == null)
                return false;

            usuarioDatos.EliminarUsuario(id);
            return true;
        }

        public List<Usuario> BuscarUsuariosPorNombre(string nombre)
        {
            return usuarioDatos.BuscarPorNombreUsuario(nombre);
        }

        public bool DepositarSaldo(string idUsuario, decimal monto, out string mensaje, out decimal saldoActualizado)
        {
            saldoActualizado = 0m;

            if (monto <= 0)
            {
                mensaje = "El monto debe ser mayor que cero.";
                return false;
            }

            var usuario = usuarioDatos.ObtenerPorId(idUsuario);
            if (usuario == null)
            {
                mensaje = "Usuario no encontrado.";
                return false;
            }

            usuario.Saldo += monto;
            usuarioDatos.ActualizarUsuario(usuario);

            saldoActualizado = usuario.Saldo;
            mensaje = $"Se depositaron {monto:C2} correctamente.";
            return true;
        }

        public string CrearUsuarioDesdeGestion(string nombre, string correo, string contraseña, string rol)
        {
            return CrearUsuario(nombre, correo, contraseña, rol);
        }

        private string CrearUsuario(string nombre, string correo, string contraseña, string rol)
        {
            if (usuarioDatos.ExisteUsuario(nombre))
                return "El nombre de usuario ya está en uso.";

            if (usuarioDatos.ExisteCorreo(correo))
                return "El correo electrónico ya está en uso.";

            if (rol != "Cliente" && rol != "Administrador")
                return "Rol inválido.";

            Usuario nuevoUsuario = new Usuario
            {
                Id = GenerarNuevoId(),
                UsuarioNombre = nombre,
                Correo = correo,
                Contraseña = contraseña,
                Rol = rol,
                Saldo = 0.0m
            };

            usuarioDatos.AgregarUsuario(nuevoUsuario);
            return "OK";
        }
    }
}