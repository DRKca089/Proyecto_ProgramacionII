using System;
using System.Collections.Generic;

public class Producto
{
    public string Codigo {  get; set; }
    public string Nombre { get; set; }
    public int CantidadDisponible { get; set; }
    public decimal Valor { get; set; }

    //Constructor sin parametros
    public Producto()
    {
    }

    //Constructor con parametros
    public Producto(string codigo, string nombre, int cantidadDisponible, decimal valor)
    {
        Codigo = codigo;
        Nombre = nombre;
        CantidadDisponible = cantidadDisponible;
        Valor = valor;
    }
}