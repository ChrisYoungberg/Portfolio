using System.Linq;

using DataStore.Plugins;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using WebApi.Controllers;
using WebApi.Dto;

namespace WebApi.UnitTest.Controllers;

[TestClass]
public class BlabsControllerTest
{
    [TestMethod]
    public void TestInstantiation()
    {
        // Arrange
        BlabsController e = new(
            new Mock<ILogger<BlabsController>>().Object,
            new InMemBlabRepository(),
            new InMemUserRepository());
        // Act
        BlabsController a = new(
            new Mock<ILogger<BlabsController>>().Object,
            new InMemBlabRepository(),
            new InMemUserRepository());
        // Assert
        Assert.AreEqual(e.GetType(), a.GetType());
        Assert.IsInstanceOfType(e, typeof(BlabsController));
    }

    [TestMethod]
    public void TestGetAllEmpty()
    {
        // Arrange
        BlabsController h = new(
            new Mock<ILogger<BlabsController>>().Object,
            new InMemBlabRepository(),
            new InMemUserRepository());
        // Act
        var a = h.GetAll();
        // Assert
        Assert.AreEqual(0, a.Count());
    }

    [TestMethod]
    public void TestPostAndGetAll()
    {
        // Arrange
        var userRepo = new InMemUserRepository();
        UserController userController = new(new Mock<ILogger<UserController>>().Object, userRepo);
        UserDto userDto = new("fubar", "fubar@example.com", "Fu", "Bar");
        userController.Post(userDto);

        BlabsController h = new(
            new Mock<ILogger<BlabsController>>().Object,
            new InMemBlabRepository(),
            userRepo);
        BlabDto d = new("fubar", "ipsum");

        // Act
        var a = h.Post(d);

        // Assert
        Assert.AreEqual("Microsoft.AspNetCore.Mvc.CreatedAtRouteResult", a.ToString());
        Assert.AreEqual(1, h.GetAll().Count());
    }

    [TestMethod]
    public void TestPostAndGetById()
    {
        // Arrange
        var userRepo = new InMemUserRepository();
        UserController userController = new(new Mock<ILogger<UserController>>().Object, userRepo);
        UserDto userDto = new("fubar", "fubar@example.com", "Fu", "Bar");
        userController.Post(userDto);
        BlabsController h = new(
            new Mock<ILogger<BlabsController>>().Object,
            new InMemBlabRepository(),
            userRepo);
        BlabDto d = new("fubar", "ipsum");
        // Act
        h.Post(d);
        var b = h.GetAll();
        var a = h.GetById(b.First().Id);
        // Assert
        Assert.AreEqual("Microsoft.AspNetCore.Mvc.OkObjectResult", a.ToString());
    }

    [TestMethod]
    public void TestPostAndValidateWithValidUser()
    {
        // Arrange
        var userRepo = new InMemUserRepository();
        UserController userController = new(new Mock<ILogger<UserController>>().Object, userRepo);
        UserDto userDto = new("fubar", "fubar@example.com", "Fu", "Bar");
        userController.Post(userDto);

        BlabsController blabController = new(
            new Mock<ILogger<BlabsController>>().Object,
            new InMemBlabRepository(),
            userRepo);
        BlabDto blab = new("fubar", "ipsum");

        // Act
        var actionResult = blabController.Post(blab);
        var createdResult = actionResult as CreatedAtRouteResult;

        // Assert
        Assert.IsInstanceOfType(actionResult, typeof(ActionResult));
        Assert.AreEqual(201, createdResult.StatusCode);
    }

    [TestMethod]
    public void TestPostAndValidateWithInvalidUser()
    {
        // Arrange
        var userRepo = new InMemUserRepository();
        UserController userController = new(new Mock<ILogger<UserController>>().Object, userRepo);
        UserDto userDto = new("fubar", "fubar@example.com", "Fu", "Bar");
        userController.Post(userDto);

        BlabsController blabController = new(
            new Mock<ILogger<BlabsController>>().Object,
            new InMemBlabRepository(),
            userRepo);
        BlabDto blab = new("foobar", "ipsum");

        // Act and Assert
        Assert.ThrowsException<BadHttpRequestException>(() => blabController.Post(blab));
    }
}