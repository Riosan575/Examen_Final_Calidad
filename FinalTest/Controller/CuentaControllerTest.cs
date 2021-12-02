using Final_Examen.Controllers;
using Final_Examen.Models;
using Final_Examen.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.Controller
{
    class CuentaControllerTest
    {
        [Test]
        public void TestCuentaVistaTransaccionesCaso01()
        {
            var mock = new Mock<ICuentaRepository>();
            mock.Setup(o => o.GetAllDetalles(1));
            var controller = new CuentaController(mock.Object);

            var result = controller.Transacciones(1) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestCuentaVistaTransaccionesCaso02()
        {
            var mock = new Mock<ICuentaRepository>();
            mock.Setup(o => o.GetCuenta(1));
            var controller = new CuentaController(mock.Object);

            var result = controller.Transacciones(1) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestCuentaCrearTransaccionCaso01()
        {
            var mock = new Mock<ICuentaRepository>();
            mock.Setup(o => o.GetCuentaForDetalle(1));
            var controller = new CuentaController(mock.Object);
            var result = controller.CrearTransaccion(new Detalle()) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestCuentaCrearTransaccionCaso02()
        {
            var mock = new Mock<ICuentaRepository>();
            mock.Setup(o => o.GetCuentaForDetalle(0));
            var controller = new CuentaController(mock.Object);
            var result = controller.CrearTransaccion(new Detalle()) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestCuentaCrearTransaccionCaso03()
        {
            var mock = new Mock<ICuentaRepository>();
            mock.Setup(o => o.GetCuentaForDetalle(1)).Returns(new Cuenta() { Limite = 10m, Saldo = 10m});
            mock.Setup(o => o.CrearTransaccion(new Detalle() { Id = 1, Categoria = "Gasto", IdCuenta = 1 }));            
            var controller = new CuentaController(mock.Object);
            var result = controller.CrearTransaccion(new Detalle() { Id = 1, Categoria = "Gasto", IdCuenta = 1}) as RedirectToActionResult;
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void TestCuentaCrearTransaccionCaso04()
        {
            var mock = new Mock<ICuentaRepository>();
            mock.Setup(o => o.CrearTransaccion(new Detalle() { Id = 1, Categoria = "Ingreso", IdCuenta = 1 }));
            var controller = new CuentaController(mock.Object);
            var result = controller.CrearTransaccion(new Detalle() { Id = 1, Categoria = "Ingreso", IdCuenta = 1 }) as RedirectToActionResult;
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void TestCuentaCrearTransaccionCaso05()
        {
            var mock = new Mock<ICuentaRepository>();
            mock.Setup(o => o.CrearTransaccion(null));
            var controller = new CuentaController(mock.Object);
            var result = controller.CrearTransaccion(null) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestCuentaCrearTransaccionCaso06()
        {
            var mock = new Mock<ICuentaRepository>();
            mock.Setup(o => o.CrearTransaccion(new Detalle() { Id = 1, Categoria = "Gasto", IdCuenta = 1 }));
            var controller = new CuentaController(mock.Object);
            var result = controller.CrearTransaccion(null) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestCrearCuentaCaso01()
        {
            var mock = new Mock<ICuentaRepository>();
            mock.Setup(o => o.CrearCuenta(new Cuenta()));
            var controller = new CuentaController(mock.Object);
            var result = controller.CrearCuenta(new Cuenta()) as RedirectToActionResult;
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
        [Test]
        public void TestCrearCuentaCaso02()
        {
            var mock = new Mock<ICuentaRepository>();
            mock.Setup(o => o.CrearCuenta(null));
            var controller = new CuentaController(mock.Object);
            var result = controller.CrearCuenta(null) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void TestCrearCuentaCaso03()
        {
            var mock = new Mock<ICuentaRepository>();
            mock.Setup(o => o.CrearCuenta(new Cuenta()));
            var controller = new CuentaController(mock.Object);
            var result = controller.CrearCuenta(null) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
