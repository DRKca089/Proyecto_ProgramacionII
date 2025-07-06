using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;

public class DetalleCompraDatos
{
    private const string ArchivoCsv = "detalle_compras.csv";
    private List<CompraDetalles> detalles = new List<CompraDetalles>();

    public DetalleCompraDatos()
    {
        CargarDesdeArchivo();
    }

    private void CargarDesdeArchivo()
    {
        detalles.Clear();

        if (!File.Exists(ArchivoCsv))
        {
            File.WriteAllText(ArchivoCsv, "IdCompra,IdUsuario,NombreProducto,Cantidad,PrecioUnitario" + Environment.NewLine);
            return;
        }

        var lineas = File.ReadAllLines(ArchivoCsv);

        foreach (var linea in lineas.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;

            var campos = linea.Split(',');

            if (campos.Length != 5) continue;

            try
            {
                var detalle = new CompraDetalles
                {
                    CodigoCompra = campos[0],
                    IdUsuario = campos[1],
                    NombreProducto = campos[2],
                    Cantidad = int.Parse(campos[3]),
                    PrecioUnitario = decimal.Parse(campos[4], CultureInfo.InvariantCulture)
                };

                detalles.Add(detalle);
            }
            catch(Exception){
                //Joseph busca que agregar aqui
            }
        }
    }

    private void GuardarTodo()
    {
        var lineas = new List<string>
        {
           "IdCompra,IdUsuario,NombreProducto,Cantidad,PrecioUnitario"
        };

        lineas.AddRange(detalles.Select(d =>$"{d.CodigoCompra},{d.IdUsuario},{d.NombreProducto},{d.Cantidad},{d.PrecioUnitario.ToString(CultureInfo.InvariantCulture)}"));

        File.WriteAllLines(ArchivoCsv, lineas);
    }

    public List<CompraDetalles> ObtenerDetallesPorCompra(string codigoCompra, string idUsuario)
    {
        return detalles.Where(d => d.CodigoCompra.Equals(codigoCompra, StringComparison.OrdinalIgnoreCase)
                     && d.IdUsuario.Equals(idUsuario, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void AgregarDetalles(List<CompraDetalles> nuevosDetalles)
    {
        detalles.AddRange(nuevosDetalles);
        GuardarTodo();
    }
}