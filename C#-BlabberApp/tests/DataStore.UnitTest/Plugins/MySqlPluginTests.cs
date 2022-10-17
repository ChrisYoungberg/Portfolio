using DataStore.Plugins;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStore.UnitTest.Plugins;

[TestClass]
public class MySqlPluginTest
{
    private readonly string _dsn;

    public MySqlPluginTest()
    {
        _dsn = "server=143.110.159.170;uid=cyoungberg1;pwd=letmein;database=cyoungberg1";
    }

    [TestMethod]
    public void MySqlPluginTest_Instantiate()
    {
        // Arrange
        MySqlPlugin e = new(_dsn);
        // Act
        MySqlPlugin a = new(_dsn);
        // Assert
        Assert.AreEqual(e.ToString(), a.ToString());
    }

    [TestMethod]
    public void MySqlPluginTest_Connect_NoException()
    {
        // Arrange
        MySqlPlugin a = new(_dsn);
        // Act and Assert
        try
        {
            a.Connect();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Assert.Fail("Expected NO exception, but got: " + ex.Message);
        }

        Assert.IsTrue(true);
    }

    [TestMethod]
    public void MySqlPluginTest_Connect_Exception()
    {
        // Arrange
        string dsn = "server=143.110.159.170;uid=cyoungberg1;pwd=letmein;database=blabber";
        MySqlPlugin a = new(dsn);
        // Act and Assert
        Assert.ThrowsException<MySql.Data.MySqlClient.MySqlException>(() => a.Connect());
    }
}