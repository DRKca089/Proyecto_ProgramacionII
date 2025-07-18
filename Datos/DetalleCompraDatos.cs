using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;

public class DetalleCompraDatos
{
    private const string ArchivoDetalleCompra = "detalle_compras.csv";
    private static readonly string CabeceraCsvDetalles = "IdCompra,IdUsuario,NombreProducto,Cantidad,PrecioUnitario";

    private List<CompraDetalles> detalles = new List<CompraDetalles>();

    public DetalleCompraDatos()
    {
        CargarDesdeArchivo();
    }

    private void CargarDesdeArchivo()
    {
        detalles.Clear();

        if (!File.Exists(ArchivoDetalleCompra))
        {
            File.WriteAllText(ArchivoDetalleCompra, CabeceraCsvDetalles + Environment.NewLine);
            return;
        }

        var lineas = File.ReadAllLines(ArchivoDetalleCompra);

        foreach (var linea in lineas.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;

            var campos = linea.Split(',');

            if (campos.Length != 5) continue;

            try
            {
                var detalle = ParsearDetalle(campos);
                if (detalle != null)
                    detalles.Add(detalle);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al parsear línea: {linea}. Detalle: {ex.Message}");
            }
        }
    }

    private void GuardarTodo()
    {
        var lineas = new List<string> { CabeceraCsvDetalles };
        lineas.AddRange(detalles.Select(FormatearDetalleParaCsv));
        File.WriteAllLines(ArchivoDetalleCompra, lineas);
    }

    public List<CompraDetalles> ObtenerDetallesPorCompra(string codigoCompra, string idUsuario)
    {
        return detalles.Where(d =>
            d.CodigoCompra.Equals(codigoCompra, StringComparison.OrdinalIgnoreCase) &&
            d.IdUsuario.Equals(idUsuario, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void AgregarDetalles(List<CompraDetalles> nuevosDetalles)
    {
        detalles.AddRange(nuevosDetalles);
        GuardarTodo();
    }

    private CompraDetalles ParsearDetalle(string[] campos)
    {
        return new CompraDetalles
        {
            CodigoCompra = campos[0],
            IdUsuario = campos[1],
            NombreProducto = campos[2],
            Cantidad = int.Parse(campos[3]),
            PrecioUnitario = decimal.Parse(campos[4], CultureInfo.InvariantCulture)
        };
    }

    private string FormatearDetalleParaCsv(CompraDetalles detalle)
    {
        return $"{detalle.CodigoCompra},{detalle.IdUsuario},{detalle.NombreProducto},{detalle.Cantidad},{detalle.PrecioUnitario.ToString(CultureInfo.InvariantCulture)}";
    }
}