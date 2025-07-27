using System;
using System.Collections.Generic;
using System.Linq;

public class UsuarioLogica
{
    private readonly UsuarioDatos usuarioDatos = new UsuarioDatos();

    // Genera un nuevo ID único para un usuario en formato
    private string GenerarNuevoId()
    {
        var usuarios = usuarioDatos.ObtenerUsuarios();
        int siguienteNumero = 1;

        if (usuarios.Any())
        {
            int numeroMaximo = usuarios.Select(u => int.Parse(u.Id.Substring(1))).Max();
            siguienteNumero = numeroMaximo + 1;
        }

        return "I" + siguienteNumero.ToString("D4");
    }

    // Registra un nuevo usuario con rol Cliente
    public string RegistrarUsuario(string nombre, string contraseña) =>
        CrearUsuario(nombre, contraseña, "Cliente");

    // Crea un usuario con un rol específico
    public string CrearUsuarioDesdeGestion(string nombre, string contraseña, string rol) =>
        CrearUsuario(nombre, contraseña, rol);

    // Lógica para crear usuarios
    private string CrearUsuario(string nombre, string contraseña, string rol)
    {
        var resultado = ValidacionUsuario.VerificarExistencia(nombre, usuarioDatos);
        if (resultado != "OK") return resultado;

        if (!ValidacionUsuario.EsRolValido(rol))
            return "Rol inválido.";

        var nuevoUsuario = new Usuario
        {
            Id = GenerarNuevoId(),
            Nombre = nombre,
            Contraseña = contraseña,
            Rol = rol,
            Saldo = 0m
        };

        usuarioDatos.AgregarUsuario(nuevoUsuario);
        return "OK";
    }

    // Valida si los datos de inicio de sesión son correctos
    public string ValidarInicioSesion(string nombre, string contraseña, string rol)
    {
        var usuario = usuarioDatos.ObtenerPorNombre(nombre);
        if (usuario == null ||
            usuario.Contraseña != contraseña ||
            !usuario.Rol.Equals(rol, StringComparison.OrdinalIgnoreCase))
        {
            return "Usuario, contraseña o rol incorrecto.";
        }

        return "OK";
    }

    // Verifica si el nombre de usuario ya está en uso
    public string ValidarRegistro(string nombre) =>
        usuarioDatos.ExisteUsuario(nombre)
            ? "El nombre de usuario ya está en uso."
            : "OK";

    // Devuelve todos los usuarios del sistema
    public List<Usuario> ObtenerTodos() => usuarioDatos.ObtenerUsuarios();

    // Obtiene un usuario por su nombre exacto
    public Usuario ObtenerUsuario(string nombre) => usuarioDatos.ObtenerPorNombre(nombre);

    // Busca usuarios cuyo nombre contenga el texto dado
    public List<Usuario> BuscarPorNombre(string nombre) =>
        usuarioDatos.BuscarPorNombre(nombre);

    // Modifica los datos de un usuario si no hay conflicto con otro usuario
    public bool ModificarUsuario(string id, string nuevoNombre, string nuevaContraseña, string nuevoRol = null)
    {
        var usuario = usuarioDatos.ObtenerPorId(id);
        if (usuario == null)
            return false;

        var usuarioExistente = usuarioDatos.ObtenerPorNombre(nuevoNombre);
        if (usuarioExistente != null && usuarioExistente.Id != id)
            return false;

        usuario.Nombre = nuevoNombre;
        usuario.Contraseña = nuevaContraseña;

        if (!string.IsNullOrWhiteSpace(nuevoRol))
            usuario.Rol = nuevoRol;

        usuarioDatos.ModificarUsuario(usuario);
        return true;
    }

    // Elimina un usuario si no es el mismo que realiza la operación
    public bool EliminarUsuario(string idEliminar, string idSolicitante)
    {
        if (idEliminar == idSolicitante)
            return false;

        var usuario = usuarioDatos.ObtenerPorId(idEliminar);
        if (usuario == null)
            return false;

        usuarioDatos.EliminarUsuario(idEliminar);
        return true;
    }

    // Deposita saldo en la cuenta del usuario
    public bool DepositarSaldo(string idUsuario, decimal monto, out string mensaje, out decimal saldoActualizado) =>
        OperarSaldo(idUsuario, monto,
            condicion: (saldo, m) => true,
            operacion: (saldo, m) => saldo + m,
            mensajeExito: "Se depositaron {0:C2} correctamente.",
            mensajeErrorCondicion: string.Empty,
            out mensaje, out saldoActualizado);

    // Descuenta saldo del usuario si tiene suficiente
    public bool DescontarSaldo(string idUsuario, decimal monto, out string mensaje, out decimal saldoActualizado) =>
        OperarSaldo(idUsuario, monto,
            condicion: (saldo, m) => saldo >= m,
            operacion: (saldo, m) => saldo - m,
            mensajeExito: "Se descontaron {0:C2} correctamente.",
            mensajeErrorCondicion: "Saldo insuficiente para esta operación.",
            out mensaje, out saldoActualizado);

    // Método para realizar operaciones de saldo
    private bool OperarSaldo(string idUsuario, decimal monto,
        Func<decimal, decimal, bool> condicion,
        Func<decimal, decimal, decimal> operacion,
        string mensajeExito,
        string mensajeErrorCondicion,
        out string mensaje,
        out decimal saldoActualizado)
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

        if (!condicion(usuario.Saldo, monto))
        {
            mensaje = mensajeErrorCondicion;
            return false;
        }

        usuario.Saldo = operacion(usuario.Saldo, monto);
        usuarioDatos.ModificarUsuario(usuario);

        saldoActualizado = usuario.Saldo;
        mensaje = string.Format(mensajeExito, monto);
        return true;
    }
}
