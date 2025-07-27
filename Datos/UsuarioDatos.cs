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

    // Carga los usuarios desde el archivo CSV
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

    // Guarda la lista actual de usuarios en el archivo CSV
    private void GuardarEnArchivo()
    {
        var lineas = new List<string> { CabeceraCsvUsuarios };

        lineas.AddRange(usuarios.Select(usuario =>
            $"{usuario.Id},{usuario.Nombre},{usuario.Contraseña},{usuario.Rol},{usuario.Saldo.ToString(CultureInfo.InvariantCulture)}"));

        File.WriteAllLines(ArchivoUsuarios, lineas);
    }

    // Recarga los datos desde el archivo para asegurar que la lista esté actualizada
    private void RecargarDatos()
    {
        CargarDesdeArchivo();
    }

    // Devuelve una copia de la lista actual de usuarios
    public List<Usuario> ObtenerUsuarios()
    {
        RecargarDatos();
        return usuarios.ToList();
    }

    // Agrega un nuevo usuario y guarda los cambios
    public void AgregarUsuario(Usuario nuevoUsuario)
    {
        RecargarDatos();
        usuarios.Add(nuevoUsuario);
        GuardarEnArchivo();
    }

    // Verifica si existe un usuario con el nombre dado
    public bool ExisteUsuario(string nombreUsuario)
    {
        RecargarDatos();
        return usuarios.Any(usuario => usuario.Nombre.Equals(nombreUsuario, StringComparison.OrdinalIgnoreCase));
    }

    // Obtiene un usuario por su nombre
    public Usuario ObtenerPorNombre(string nombre)
    {
        RecargarDatos();
        return usuarios.FirstOrDefault(usuario => usuario.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }

    // Obtiene un usuario por su ID
    public Usuario ObtenerPorId(string id)
    {
        RecargarDatos();
        return usuarios.FirstOrDefault(usuario => usuario.Id.Equals(id));
    }

    // Modifica un usuario existente y guarda los cambios
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

    // Elimina un usuario por su ID y guarda los cambios
    public void EliminarUsuario(string id)
    {
        RecargarDatos();

        var usuario = BuscarPorId(id);
        if (usuario == null) return;

        var comprasUsuario = compraDatos.ObtenerComprasPorUsuario(id);
        var codigosCompras = comprasUsuario.Select(compra => compra.Codigo).ToList();

        usuarios.Remove(usuario);
        GuardarEnArchivo();
    }

    // Busca usuarios por nombre y devuelve una lista de coincidencias
    public List<Usuario> BuscarPorNombre(string nombreUsuario)
    {
        RecargarDatos();
        return usuarios
            .Where(usuario => usuario.Nombre.IndexOf(nombreUsuario, StringComparison.OrdinalIgnoreCase) >= 0)
            .ToList();
    }

    // Busca un usuario por su ID
    private Usuario BuscarPorId(string id)
    {
        return usuarios.FirstOrDefault(usuario => usuario.Id == id);
    }
}
