using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Datos
{
    public class UsuarioDatos
    {
        private const string ArchivoCsv = "usuarios.csv";
        private List<Usuario> usuarios = new List<Usuario>();

        public UsuarioDatos()
        {
            CargarDesdeArchivo();
        }

        private void CargarDesdeArchivo()
        {
            usuarios.Clear();

            if (!File.Exists(ArchivoCsv))
            {
                File.WriteAllLines(ArchivoCsv, new[]
                {
                    "Id,NombreUsuario,Contraseña,RolUsuario,Saldo"
                });
            }

            var lineas = File.ReadAllLines(ArchivoCsv);
            foreach (var linea in lineas.Skip(1))
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;
                var campos = linea.Split(',');
                if (campos.Length != 5) continue;

                try
                {
                    usuarios.Add(new Usuario
                    {
                        Id = campos[0],
                        NombreUsuario = campos[1],
                        Contraseña = campos[2],
                        RolUsuario = campos[3],
                        Saldo = decimal.Parse(campos[4], CultureInfo.InvariantCulture)
                    });
                }
                catch
                {
                    // Ignorar líneas con error de formato
                }
            }
        }

        private void GuardarEnArchivo()
        {
            var lineas = new List<string>
            {
                "Id,NombreUsuario,Contraseña,RolUsuario,Saldo"
            };

            lineas.AddRange(usuarios.Select(u =>
            $"{u.Id},{u.NombreUsuario},{u.Contraseña},{u.RolUsuario},{u.Saldo.ToString(CultureInfo.InvariantCulture)}"));

            File.WriteAllLines(ArchivoCsv, lineas);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            CargarDesdeArchivo();
            return usuarios.ToList();
        }

        public void AgregarUsuario(Usuario nuevoUsuario)
        {
            usuarios.Add(nuevoUsuario);
            GuardarEnArchivo();
        }

        public bool ExisteUsuario(string nombreUsuario)
        {
            CargarDesdeArchivo();
            return usuarios.Any(u => u.NombreUsuario.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
        }

        public Usuario ObtenerPorNombre(string nombre)
        {
            CargarDesdeArchivo();
            return usuarios.FirstOrDefault(u => u.NombreUsuario.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public Usuario ObtenerPorId(string id)
        {
            CargarDesdeArchivo();
            return usuarios.FirstOrDefault(u => u.Id.Equals(id));
        }

        public void ActualizarUsuario(Usuario usuarioActualizado)
        {
            CargarDesdeArchivo();
            var usuario = usuarios.FirstOrDefault(u => u.Id == usuarioActualizado.Id);
            if (usuario != null)
            {
                usuario.NombreUsuario = usuarioActualizado.NombreUsuario;
                usuario.Contraseña = usuarioActualizado.Contraseña;
                usuario.RolUsuario = usuarioActualizado.RolUsuario;
                usuario.Saldo = usuarioActualizado.Saldo;
                GuardarEnArchivo();
            }
        }

        public void EliminarUsuario(string id)
        {
            CargarDesdeArchivo();
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
                GuardarEnArchivo();
            }
        }

        public List<Usuario> BuscarPorNombreUsuario(string nombreUsuario)
        {
            CargarDesdeArchivo();
            return usuarios.FindAll(u => u.NombreUsuario.IndexOf(nombreUsuario, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
