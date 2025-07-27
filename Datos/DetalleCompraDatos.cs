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

    // Carga todos los detalles de compra desde el archivo CSV
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

    // Guarda todos los detalles actuales en el archivo CSV
    private void GuardarTodo()
    {
        var lineas = new List<string> { CabeceraCsvDetalles };
        lineas.AddRange(detalles.Select(FormatearDetalleParaCsv));
        File.WriteAllLines(ArchivoDetalleCompra, lineas);
    }

    // Devuelve los detalles de una compra específica por su código y usuario
    public List<CompraDetalles> ObtenerDetallesPorCompra(string codigoCompra, string idUsuario)
    {
        return detalles.Where(detalleCompra =>
            detalleCompra.CodigoCompra.Equals(codigoCompra, StringComparison.OrdinalIgnoreCase) &&
            detalleCompra.IdUsuario.Equals(idUsuario, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    // Agrega una lista de nuevos detalles de compra y los guarda en el archivo
    public void AgregarDetalles(List<CompraDetalles> nuevosDetalles)
    {
        detalles.AddRange(nuevosDetalles);
        GuardarTodo();
    }

    // Convierte un arreglo de campos CSV en un objeto CompraDetalles
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

    // Convierte un objeto CompraDetalles en una línea CSV
    private string FormatearDetalleParaCsv(CompraDetalles detalle)
    {
        return $"{detalle.CodigoCompra},{detalle.IdUsuario},{detalle.NombreProducto},{detalle.Cantidad},{detalle.PrecioUnitario.ToString(CultureInfo.InvariantCulture)}";
    }
}