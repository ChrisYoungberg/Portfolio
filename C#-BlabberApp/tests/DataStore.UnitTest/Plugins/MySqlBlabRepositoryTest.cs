using DataStore.Plugins;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStore.UnitTest.Plugins;

[TestClass]
public class MySqlBlabRepositoryTest
{
    private readonly MySqlBlabRepository _h;
    private readonly string _dsn;

    public MySqlBlabRepositoryTest()
    {
        _dsn = "server=143.110.159.170;uid=cyoungberg1;pwd=letmein;database=cyoungberg1";
        _h = new MySqlBlabRepository(_dsn);
    }

    [TestInitialize]
    public void Setup()
    {}

    [TestCleanup]
    public void TearDown()
    {
        _h.RemoveAll();
    }

    [TestMethod]
    public void MySqlBlabRepository_Instantiate()
    {
        // Arrange
        // Act
        MySqlBlabRepository a = new(_dsn);
        // Assert
        Assert.AreEqual(_h.ToString(), a.ToString());
    }

    [TestMethod]
    public void MySqlBlabRepository_Connect_NoException()
    {
        // Arrange
        MySqlBlabRepository a = new(_dsn);
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
    public void MySqlBlabRepositoryTest_Connect_Exception()
    {
        // Arrange
        string dsn = "server=143.110.159.170;uid=cyoungberg1;pwd=letmein;database=blabber";
        MySqlBlabRepository a = new(dsn);
        // Act and Assert
        Assert.ThrowsException<MySql.Data.MySqlClient.MySqlException>(() => a.Connect());
    }

    [TestMethod]
    public void MySqlBlabRepositoryTest_Insert()
    {
        // Arrange
        Blab e = new(
            "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet",
            "foobar"
        );
        // Act
        _h.Add(e);
        Blab a = _h.GetById(e.Id);
        // Assert
        Assert.AreEqual(e.Id.ToString(), a.Id.ToString());
        Assert.AreEqual(e.Content, a.Content);
        Assert.AreEqual(e.Username, a.Username);
    }
    
    [TestMethod]
         public void MySqlBlabRepositoryTest_InsertTwo()
         {
             // Arrange
             Blab e = new(
                 "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet",
                 "foobar"
             );
             // Act
             _h.Add(e);
             Blab a = _h.GetById(e.Id);
             Assert.AreEqual(e.Content, a.Content);
             Assert.AreEqual(e.Username, a.Username);
         }
}