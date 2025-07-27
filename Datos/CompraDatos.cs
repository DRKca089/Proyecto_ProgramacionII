using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class CompraDatos
{
    private const string ArchivoCompras = "compras.csv";
    private static readonly string CabeceraCsvCompras = "IdCompra,IdUsuario,Fecha,Total";

    private List<Compra> compras = new List<Compra>();

    public CompraDatos()
    {
        CargarCompras();
    }

    // Carga las compras desde el archivo CSV
    private void CargarCompras()
    {
        if (!File.Exists(ArchivoCompras))
        {
            File.WriteAllText(ArchivoCompras, CabeceraCsvCompras + "\n");
            return;
        }

        compras.Clear();

        var lineas = File.ReadAllLines(ArchivoCompras).Skip(1);
        foreach (var linea in lineas)
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;

            var campos = linea.Split(',');
            if (campos.Length != 4) continue;

            try
            {
                var compra = ParsearCompra(campos);
                if (compra != null)
                    compras.Add(compra);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al parsear línea: {linea}. Detalle: {ex.Message}");
            }
        }
    }

    // Guarda las compras en el archivo CSV
    private void GuardarCompras()
    {
        var lineas = new List<string> { CabeceraCsvCompras };
        lineas.AddRange(compras.Select(FormatearCompraParaCsv));
        File.WriteAllLines(ArchivoCompras, lineas);
    }

    // Agrega una nueva compra y guarda los cambios
    public void AgregarCompra(Compra compra)
    {
        compras.Add(compra);
        GuardarCompras();
    }

    // Devuelve todas las compras
    public List<Compra> ObtenerCompras()
    {
        return compras.ToList();
    }

    // Devuelve las compras de un usuario específico
    public List<Compra> ObtenerComprasPorUsuario(string idUsuario)
    {
        return compras.Where(compra => compra.IdUsuario == idUsuario).ToList();
    }

    // Convierte los campos de una línea CSV en una instancia de Compra
    private Compra ParsearCompra(string[] campos)
    {
        return new Compra
        {
            Codigo = campos[0],
            IdUsuario = campos[1],
            Fecha = DateTime.Parse(campos[2]),
            Total = decimal.Parse(campos[3], CultureInfo.InvariantCulture)
        };
    }
    
    // Convierte una instancia de Compra en una línea CSV
    private string FormatearCompraParaCsv(Compra compra)
    {
        return $"{compra.Codigo},{compra.IdUsuario},{compra.Fecha},{compra.Total.ToString(CultureInfo.InvariantCulture)}";
    }
}
