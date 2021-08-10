using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planeta.Controllers;
using Planeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Planeta.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=Planeta;Trusted_Connection=True;";

        [TestMethod]
        public void TestIndexView()
        {
            // Arrange
            HomeController controller = new HomeController(new UserRepository(connectionString));

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDetailsTest()
        {
            // Arrange
            HomeController controller = new HomeController(new UserRepository(connectionString));

            // Act
            ViewResult result = controller.Details(13) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateUserTest()
        {
            // Arrange
            HomeController controller = new HomeController(new UserRepository(connectionString));

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EditUserByIdTest()
        {
            // Arrange
            HomeController controller = new HomeController(new UserRepository(connectionString));

            // Act
            ViewResult result = controller.Edit(21) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteNonexistentUserByIdTest()
        {
            // Arrange
            HomeController controller = new HomeController(new UserRepository(connectionString));

            // Act
            ViewResult result = controller.Delete(10) as ViewResult;

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteExistUserByIdTest()
        {
            // Arrange
            HomeController controller = new HomeController(new UserRepository(connectionString));

            // Act
            ViewResult result = controller.Delete(22) as ViewResult;

            //Assert
            Assert.IsNull(result);
        }
    }
}
