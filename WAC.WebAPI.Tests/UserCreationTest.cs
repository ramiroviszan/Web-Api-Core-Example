using Microsoft.VisualStudio.TestTools.UnitTesting;
using WAC.WebAPI.Controllers;
using WAC.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace WAC.WebAPI.Tests
{
    [TestClass]
    public class UserCreationTest
    {
        [TestMethod]
        public void CreateValidUserTest()
        {
            //Arrange
            var modelIn = new UserModelIn() { Username = "Alberto", Password = "pass", Age = 2 }; 
            var controller = new UsersController();
            var result = controller.Post(modelIn);

            //Act
            var createdResult = result as CreatedAtRouteResult;
            var modelOut = createdResult.Value as UserModelOut;

            //Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("GetById", createdResult.RouteName);
            Assert.AreEqual(201, createdResult.StatusCode);
            Assert.AreEqual(modelIn.Username, modelOut.Username);
            Assert.AreEqual(modelIn.Age, modelOut.Age);
        }

        [TestMethod]
        public void CreateFailedUserTest()
        {
            //Arrange
            var modelIn = new UserModelIn(); 
            var controller = new UsersController();

            //We need to force the error in de ModelState
            controller.ModelState.AddModelError("", "Error");
            var result = controller.Post(modelIn);

            //Act
            var createdResult = result as BadRequestObjectResult;

            //Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(400, createdResult.StatusCode);
        }
    }
}
