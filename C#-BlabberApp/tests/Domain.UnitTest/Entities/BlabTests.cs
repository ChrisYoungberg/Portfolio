using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.Domain.UnitTests.Entities;

[TestClass]
public class BlabTests
{
    [TestMethod]
    public void NewBlabShouldReturnCorrectValues()
    {
        // Arrange
        var u = new User("foobar", "foobar@example.com");
        var e = new Blab("Lorem ipsum voluptate proident ut ut irure ex ex aliqua in esse non eiusmod adipisicing exercitation consequat in quis est.", u.Username);
        // Act
        var a = new Blab("Lorem ipsum voluptate proident ut ut irure ex ex aliqua in esse non eiusmod adipisicing exercitation consequat in quis est.", u.Username);
        // Assert
        Assert.AreNotEqual(e.Id, a.Id, "ID's are equal");
        Assert.AreEqual(e.Username, a.Username, "User are NOT equal");
        Assert.AreEqual(e.Content, a.Content, "Content is NOT equal");
    }

    public void TestBlabCreation()
    {
        //Arrange
        Blab e = new Blab();
        //Act
        Blab a = new Blab();
        //Assert
        Assert.IsInstanceOfType(a, e.GetType());
    }

    [TestMethod]
    public void TestBlabSet()
    {
        //Arrage
        var eContent = "Test";

        Blab b = new Blab();
        b.Content = "Test";
        //Act
        var aContent = b.Content;
        //Assert
        Assert.AreEqual(eContent, aContent, "Content");
    }

    [TestMethod]
    public void TestBlabGet()
    {
        //Arrange
        Blab b = new Blab();
        //Act
//        var aID = b.GetID();
        var aContent = b.Content;
        var aCreated = b.DttmCreated;
        //Assert
//        Assert.IsInstanceOfType(aID, typeof(Guid), "ID");
//        Assert.AreNotEqual(aID, Guid.Empty, "ID Check if empty");
//        Assert.IsNull(aContent, "Content");
//        Assert.IsInstanceOfType(aCreated, typeof(DateTime), "Created");
        Assert.IsNotNull(aCreated, "Created Not NULL");
//        Assert.ThrowsException<NotImplementedException>(() => b.Validate(), "Validation");
    }
}
