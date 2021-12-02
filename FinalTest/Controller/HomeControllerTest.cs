using Final_Examen.Controllers;
using Final_Examen.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.Controller
{
    class HomeControllerTest
    {
        [Test]
        public void TestHomeIndex()
        {
            var mock = new Mock<IHomeRepository>();
            mock.Setup(o => o.GetAllCuentas());        
            var controller = new HomeController(mock.Object);

            var result = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}
