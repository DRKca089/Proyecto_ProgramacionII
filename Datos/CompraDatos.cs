using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;

public class CompraDatos
{
    private const string ArchivoCompras = "compras.csv";
    private static readonly string CabeceraCsv = "IdCompra,IdUsuario,Fecha,Total";

    private List<Compra> compras = new List<Compra>();

    public CompraDatos()
    {
        CargarCompras();
    }

    private void CargarCompras()
    {
        if (!File.Exists(ArchivoCompras))
        {
            File.WriteAllText(ArchivoCompras, CabeceraCsv + "\n");
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

    private void GuardarCompras()
    {
        var lineas = new List<string> {CabeceraCsv};
        lineas.AddRange(compras.Select(FormatearCompraParaCsv));
        File.WriteAllLines(ArchivoCompras, lineas);
    }

    public void AgregarCompra(Compra compra)
    {
        compras.Add(compra);
        GuardarCompras();
    }

    public List<Compra> ObtenerCompras()
    {
        return compras.ToList();
    }

    public List<Compra> ObtenerComprasPorUsuario(string idUsuario)
    {
        return compras.Where(c => c.IdUsuario == idUsuario).ToList();
    }

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

    private string FormatearCompraParaCsv(Compra c)
    {
        return $"{c.Codigo},{c.IdUsuario},{c.Fecha},{c.Total.ToString(CultureInfo.InvariantCulture)}";
    }
}
