using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Http.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prueba_TEV.Controllers;
using Prueba_TEV.Models;

namespace Prueba_TEV.Tests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void GetReturnsUser()
        {
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.GetUser(42)).Returns(new User { ID = 1 });

            var controller = new UserController(mockRepository.Object);

            IHttpActionResult actionResult = controller.Get(42);
            var contentResult = actionResult as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.ID);
        }

        [TestMethod]
        public void GetReturnsNotFound()
        {
            var mockRepository = new Mock<IUserRepository>();
            var controller = new UserController(mockRepository.Object);

            IHttpActionResult actionResult = controller.Get(99);

            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostSetsLocationHeader()
        {
            User user = new User()
            {
                ID = 31,
                Name = "Andres",
                LastName = "Arango",
                Address = "Medellin, Colombia",
                CreateDate = DateTime.Today,
                UpdateDate = DateTime.Today
            };

            var mockRepository = new Mock<IUserRepository>();
            var controller = new UserController(mockRepository.Object);

            IHttpActionResult actionResult = controller.Post(user);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<User>;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(31, createdResult.RouteValues["ID"]);
        }

        [TestMethod]
        public void PutReturnsUser()
        {
            User user = new User()
            {
                ID = 1,
                Name = "Sebastian",
                LastName = "Ortiz Serna",
                Address = "Medellin, Colombia",
                UpdateDate = DateTime.Today
            };

            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(x => x.UpdateUser(1, user)).Returns(user);

            var controller = new UserController(mockRepository.Object);

            IHttpActionResult actionResult = controller.Put(1, user);
            var contentResult = actionResult as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.ID);
        }

        [TestMethod]
        public void DeleteReturnsOk()
        {
            var mockRepository = new Mock<IUserRepository>();
            var controller = new UserController(mockRepository.Object);

            IHttpActionResult actionResult = controller.Delete(2);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }
    }
}
