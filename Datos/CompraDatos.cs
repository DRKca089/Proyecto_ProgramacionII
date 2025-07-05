using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class CompraDatos
{
    private const string ArchivoCompras = "compras.csv";
    private List<Compra> compras = new List<Compra>();

    public CompraDatos()
    {
        CargarCompras();
    }

    private void CargarCompras()
    {
        if (!File.Exists(ArchivoCompras))
        {
            File.WriteAllText(ArchivoCompras, "IdCompra,IdUsuario,Fecha,Total\n");
            return;
        }

        var lineas = File.ReadAllLines(ArchivoCompras).Skip(1);
        compras.Clear();

        foreach (var linea in lineas)
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;
            var campos = linea.Split(',');
            if (campos.Length != 4) continue;
            try
            {
                compras.Add(new Compra
                {
                    Codigo = campos[0],
                    IdUsuario = campos[1],
                    Fecha = DateTime.Parse(campos[2]),
                    Total = decimal.Parse(campos[3], CultureInfo.InvariantCulture)
                });
            }
            catch (Exception)
            {
                //Joseph, mira como podrias agregar algo aqui
            }
        }
    }

    private void GuardarCompras()
    {
        var lineas = new List<string>
        {
            "IdCompra,IdUsuario,Fecha,Cantidad,Total"
        };
        lineas.AddRange(compras.Select(c =>
            $"{c.Codigo},{c.IdUsuario},{c.Fecha},{c.Total.ToString(System.Globalization.CultureInfo.InvariantCulture)}"));
        File.WriteAllLines(ArchivoCompras, lineas);
    }

    public void AgregarCompra(Compra compra)
    {
        compras.Add(compra);
        GuardarCompras();
    }

    public void EliminarComprasPorUsuario(string idUsuario)
    {
        CargarCompras(); 
        compras = compras.Where(c => c.IdUsuario != idUsuario).ToList();
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
}
