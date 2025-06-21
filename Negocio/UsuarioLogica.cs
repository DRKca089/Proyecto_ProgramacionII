using Datos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Negocio
{
    public class UsuarioLogica
    {
        private UsuarioDatos usuarioDatos = new UsuarioDatos();
        // Generar ID personalizada
        private string GenerarNuevoId()
        {
            List<Usuario> usuarios = usuarioDatos.ObtenerUsuarios();

            if (usuarios.Count == 0)
                return "I0001";

            string ultimoId = usuarios.OrderByDescending(u => u.Id).First().Id;
            int numero = int.Parse(ultimoId.Substring(1));
            numero++;

            return "I" + numero.ToString("D4");
        }
        // Registrar usuario con validación de negocio
        public string RegistrarUsuario(string usuarioNombre, string correo, string contraseña)
        {
            if (usuarioDatos.ExisteUsuario(usuarioNombre))
                return "El nombre de usuario ya está en uso.";

            if (usuarioDatos.ExisteCorreo(correo))
                return "El correo electrónico ya está en uso.";

            Usuario nuevoUsuario = new Usuario
            {
                Id = GenerarNuevoId(),
                UsuarioNombre = usuarioNombre,
                Correo = correo,
                Contraseña = contraseña,
                Rol = "Cliente",
                Saldo = 0.00m
            };

            usuarioDatos.AgregarUsuario(nuevoUsuario);

            return "OK";
        }

        public string ValidarInicioSesion(string nombre, string contraseña, string rol)
        {
            var usuario = usuarioDatos.ObtenerPorNombre(nombre);
            if (usuario == null || usuario.Contraseña != contraseña || !usuario.Rol.Equals(rol, StringComparison.OrdinalIgnoreCase))
            {
                return "Usuario, contraseña o rol incorrecto.";
            }

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

        public Usuario ObtenerUsuario(string nombre)
        {
            return usuarioDatos.ObtenerPorNombre(nombre);
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

        public bool ActualizarUsuario(string id, string nuevoNombre, string nuevoCorreo, string nuevaContraseña)
        {
            var usuario = usuarioDatos.ObtenerPorId(id);
            if (usuario == null)
                return false;

            usuario.UsuarioNombre = nuevoNombre;
            usuario.Correo = nuevoCorreo;
            usuario.Contraseña = nuevaContraseña;

            usuarioDatos.ActualizarUsuario(usuario);
            return true;
        }

    }
}
