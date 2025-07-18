using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class UsuarioDatos
{
    private const string ArchivoUsuarios = "usuarios.csv";
    private static readonly string CabeceraCsvUsuarios = "Id,NombreUsuario,Contraseña,RolUsuario,Saldo";

    private List<Usuario> usuarios = new List<Usuario>();
    private CompraDatos compraDatos = new CompraDatos();

    public UsuarioDatos()
    {
        CargarDesdeArchivo();
    }

    private void CargarDesdeArchivo()
    {
        usuarios.Clear();

        if (!File.Exists(ArchivoUsuarios))
        {
            File.WriteAllLines(ArchivoUsuarios, new[] { CabeceraCsvUsuarios });
            return;
        }

        var lineas = File.ReadAllLines(ArchivoUsuarios).Skip(1);
        foreach (var linea in lineas)
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;

            var campos = linea.Split(',');
            if (campos.Length != 5) continue;

            if (decimal.TryParse(campos[4], NumberStyles.Any, CultureInfo.InvariantCulture, out var saldo))
            {
                usuarios.Add(new Usuario
                {
                    Id = campos[0],
                    Nombre = campos[1],
                    Contraseña = campos[2],
                    Rol = campos[3],
                    Saldo = saldo
                });
            }
        }
    }

    private void GuardarEnArchivo()
    {
        var lineas = new List<string> { CabeceraCsvUsuarios };

        lineas.AddRange(usuarios.Select(u =>
            $"{u.Id},{u.Nombre},{u.Contraseña},{u.Rol},{u.Saldo.ToString(CultureInfo.InvariantCulture)}"));

        File.WriteAllLines(ArchivoUsuarios, lineas);
    }

    // Método privado para asegurar que los datos estén cargados
    private void RecargarDatos()
    {
        CargarDesdeArchivo();
    }

    public List<Usuario> ObtenerUsuarios()
    {
        RecargarDatos();
        return usuarios.ToList();
    }

    public void AgregarUsuario(Usuario nuevoUsuario)
    {
        RecargarDatos();
        usuarios.Add(nuevoUsuario);
        GuardarEnArchivo();
    }

    public bool ExisteUsuario(string nombreUsuario)
    {
        RecargarDatos();
        return usuarios.Any(u => u.Nombre.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
    }

    public Usuario ObtenerPorNombre(string nombre)
    {
        RecargarDatos();
        return usuarios.FirstOrDefault(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }

    public Usuario ObtenerPorId(string id)
    {
        RecargarDatos();
        return usuarios.FirstOrDefault(u => u.Id.Equals(id));
    }

    public void ModificarUsuario(Usuario usuarioModificado)
    {
        RecargarDatos();

        var usuario = BuscarPorId(usuarioModificado.Id);
        if (usuario == null) return;

        usuario.Nombre = usuarioModificado.Nombre;
        usuario.Contraseña = usuarioModificado.Contraseña;
        usuario.Rol = usuarioModificado.Rol;
        usuario.Saldo = usuarioModificado.Saldo;

        GuardarEnArchivo();
    }

    public void EliminarUsuario(string id)
    {
        RecargarDatos();

        var usuario = BuscarPorId(id);
        if (usuario == null) return;

        var comprasUsuario = compraDatos.ObtenerComprasPorUsuario(id);
        var codigosCompras = comprasUsuario.Select(c => c.Codigo).ToList();

        usuarios.Remove(usuario);
        GuardarEnArchivo();
    }

    public List<Usuario> BuscarPorNombre(string nombreUsuario)
    {
        RecargarDatos();
        return usuarios
            .Where(u => u.Nombre.IndexOf(nombreUsuario, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();
    }

    private Usuario BuscarPorId(string id)
    {
        return usuarios.FirstOrDefault(u => u.Id == id);
    }
}
