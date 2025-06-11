using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class ProductoLogicaTests
{
    private ProductoLogica logica;

    [TestInitialize]
    public void Setup()
    {
        logica = new ProductoLogica();
    }

    [TestMethod]
    [TestCategory("Agregar")]
    public void AgregarProducto()
    {
        var producto = new Producto { Codigo = "0001", Nombre = "Leche", CantidadDisponible = 10, Valor = 15.5m };

        bool resultado = logica.Agregar(producto);

        Assert.IsTrue(resultado);
        var encontrado = logica.BuscarPorCodigo("0001");
        Assert.IsNotNull(encontrado);
        Assert.AreEqual("Leche", encontrado.Nombre);
    }


    [TestMethod]
    [TestCategory("Modificar")]
    public void ModificarProducto()
    {
        var producto = new Producto { Codigo = "0001", Nombre = "Leche", CantidadDisponible = 10, Valor = 15.5m };
        logica.Agregar(producto);
        var modificado = new Producto { Codigo = "0001", Nombre = "Leche Descremada", CantidadDisponible = 20, Valor = 16.0m };

        bool resultado = logica.Modificar(modificado);

        Assert.IsTrue(resultado);
        var encontrado = logica.BuscarPorCodigo("0001");
        Assert.AreEqual("Leche Descremada", encontrado.Nombre);
        Assert.AreEqual(20, encontrado.CantidadDisponible);
        Assert.AreEqual(16.0m, encontrado.Valor);
    }

    [TestMethod]
    [TestCategory("Eliminar")]
    public void EliminarProducto()
    {
        var producto = new Producto { Codigo = "0001", Nombre = "Leche", CantidadDisponible = 10, Valor = 15.5m };
        logica.Agregar(producto);

        bool resultado = logica.Eliminar("0001");

        Assert.IsTrue(resultado);
        var encontrado = logica.BuscarPorCodigo("0001");
        Assert.IsNull(encontrado);
    }

    [TestMethod]
    [TestCategory("BuscarPorCodigo")]
    public void BuscarPorCodigo()
    {
        logica.Agregar(new Producto { Codigo = "0004", Nombre = "Leche Entera", CantidadDisponible = 10, Valor = 15.5m });
        logica.Agregar(new Producto { Codigo = "0002", Nombre = "Leche Descremada", CantidadDisponible = 5, Valor = 16.0m });
        logica.Agregar(new Producto { Codigo = "0003", Nombre = "Yogurt", CantidadDisponible = 7, Valor = 12.0m });

        var resultado = logica.BuscarPorCodigo("000");

        Assert.IsNotNull(resultado);
        Assert.AreEqual("Leche Entera", resultado.Nombre);
    }

        [TestMethod]
    [TestCategory("BuscarPorNombre")]
    public void BuscarPorNombres()
    {
        logica.Agregar(new Producto { Codigo = "0001", Nombre = "Yougr Entera", CantidadDisponible = 10, Valor = 15.5m });
        logica.Agregar(new Producto { Codigo = "0002", Nombre = "Yogurt Descremada", CantidadDisponible = 5, Valor = 16.0m });
        logica.Agregar(new Producto { Codigo = "0003", Nombre = "Yogurt", CantidadDisponible = 7, Valor = 12.0m });

        List<Producto> resultados = logica.BuscarPorNombre("leche");

        Assert.AreEqual(2, resultados.Count);
    }
}

