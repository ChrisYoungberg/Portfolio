using DataStore.Plugins;

using Domain.Entities;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStore.UnitTest.Plugins;

[TestClass]
public class MySqlUserRepositoryTest
{
    private readonly MySqlUserRepository _h;
    private readonly string _dsn;

    public MySqlUserRepositoryTest()
    {
        _dsn = "server=143.110.159.170;uid=cyoungberg1;pwd=letmein;database=cyoungberg1";
        _h = new MySqlUserRepository(_dsn);
    }

    [TestInitialize]
    public void Setup()
    {
    }

    [TestCleanup]
    public void TearDown()
    {
        _h.RemoveAll();
    }

    [TestMethod]
    public void MySqlUserRepository_Instantiate()
    {
        // Arrange
        // Act
        MySqlUserRepository a = new(_dsn);
        // Assert
        Assert.AreEqual(_h.ToString(), a.ToString());
    }

    [TestMethod]
    public void MySqlUserRepository_Connect_NoException()
    {
        // Arrange
        MySqlUserRepository a = new(_dsn);
        // Act and Assert
        try
        {
            a.Connect();
        }
        catch (System.Exception ex)
        {
            Assert.Fail("Expected NO exception, but got: " + ex.Message);
        }

        Assert.IsTrue(true);
    }

    [TestMethod]
    public void MySqlUserRepository_Connect_Exception()
    {
        // Arrange
        string dsn = "server=143.110.159.170;uid=cyoungberg1;pwd=letmein;database=blabber";
        MySqlUserRepository a = new(dsn);
        // Act and Assert
        Assert.ThrowsException<MySql.Data.MySqlClient.MySqlException>(() => a.Connect());
    }

    [TestMethod]
    public void MySqlUserRepository_Insert()
    {
        // Arrange
        User e = new("foobar", "foo@bar.com");
        e.FirstName = "foo";
        e.LastName = "bar";
        // Act
        _h.Add(e);
        User a = _h.GetById(e.Id);
        // Assert
        Assert.AreEqual(e.Id.ToString(), a.Id.ToString());
        Assert.AreEqual(e.Email, a.Email);
        Assert.AreEqual(e.Username, a.Username);
    }

    [TestMethod]
    public void MySqlUserRepository_InsertTwo()
    {
        // Arrange
        User e1 = new("foobar", "foo@bar.com");
        e1.FirstName = "foo";
        e1.LastName = "bar";
        User e2 = new("fubar", "fu@bar.com");
        e2.FirstName = "fu";
        e2.LastName = "bar";
        // Act
        _h.Add(e1);
        _h.Add(e2);
        // Assert
        Assert.IsTrue(true);
    }
}