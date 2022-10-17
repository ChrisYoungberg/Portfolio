namespace DataStore.Plugins;

public class MySqlPlugin
{
    public MySql.Data.MySqlClient.MySqlConnection? Conn { get; }
    private string connectionString; //Also know as DSN

    public MySqlPlugin(string connStr)
    {
        this.connectionString = connStr;
        this.Conn = new MySql.Data.MySqlClient.MySqlConnection(
            this.connectionString
        );
    }

    public void Connect()
    {
        try
        {
            Conn?.Open();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            throw ex;
        }
    }
}