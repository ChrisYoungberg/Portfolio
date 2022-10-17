using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlabberApp.Domain.UnitTests.Entities;

[TestClass]
public class UserTest
{
    [TestMethod]
    public void TestUserCreation()
    {
        //Arrange
        User e = new User();
        //Act
        User a = new User();
        //Assert
        Assert.IsInstanceOfType(a, e.GetType());
    }

    [TestMethod]
    public void TestUserSet()
    {
        //Arrange
        var eFirstName = "Foo";
        var eLastName = "Bar";
//        var eEmail = "u@test.com";
        var eUsername = "u";
//        var ePasswrod = "p";

        User u = new User();
        u.FirstName = "Foo";
        u.LastName = "Bar";
//        u.Email = "u@test.com";
        u.Username = "u";
//        u.Passwrod = "p";
        //Act
        var aFirstName = u.FirstName;
        var aLastName = u.LastName;
//        var aEmail = u.Email;
        var aUsername = u.Username;
//        var aPassword = u.Passwrod;
        //Assert
        Assert.AreEqual(eFirstName, aFirstName, "FirstName");
        Assert.AreEqual(eLastName, aLastName, "LastName");
//        Assert.AreEqual(eEmail, aEmail, "Email");
        Assert.AreEqual(eUsername, aUsername, "Username");
//        Assert.AreEqual(ePasswrod, aPassword, "Password");
    }

    [TestMethod]
    public void TestUserFullName() 
    {
        //Arrange
        var e1 = "Foo Bar";
        var e2 = "Bar, Foo";

        User u = new User();
        u.FirstName = "Foo";
        u.LastName = "Bar";
        //Act
        var a1 = u.FullNameFirstLast;
        var a2 = u.FullNameLastFirst;
        //Assert
        Assert.AreEqual(e1, a1, "FirstLast");
        Assert.AreEqual(e2, a2, "LastFirst");
    }

    [TestMethod]
    public void TestUserGet()
    {
        //Arrange
        User u = new User();
        //Act
//        var aID = u.GetID();
        var aFirstName = u.FirstName;
        var aLastName = u.LastName;
        var aEmail = u.Email;
        var aUsername = u.Username;
//        var aPassword = u.Passwrod;
        var aCreatedDttm = u.DttmCreated;
        //Assert
//        Assert.IsInstanceOfType(aID, typeof(Guid), "ID");
//        Assert.AreNotEqual(aID, Guid.Empty, "ID");
        Assert.IsNull(aFirstName, "First Name");
        Assert.IsNull(aLastName, "Last Name");
        Assert.IsNull(aEmail, "Email");
        Assert.IsNull(aUsername, "Username");
//        Assert.IsNull(aPassword, "Password");
//        Assert.IsInstanceOfType(aCreatedDttm, typeof(DateTime), "Created");
        Assert.IsNotNull(aCreatedDttm, "Created");
//        Assert.ThrowsException<NotImplementedException>(() => u.Validate(), "Validation");
    }
}