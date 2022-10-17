using System.Data;

using Domain.Common.Interfaces;
using Domain.Entities;

using MySql.Data.MySqlClient;

namespace DataStore.Plugins;

public class MySqlBlabRepository : MySqlPlugin, IBlabRepository
{
    private readonly MySqlCommand _cmd;
    private static string _dbname = "`cyoungberg1`";
    private static string _tbname = "`blabs`";
    private readonly string _srcname = _dbname + "." + _tbname;


    public MySqlBlabRepository(string connStr) : base(connStr)
    {
        _cmd = new MySqlCommand();
        _cmd.Connection = this.Conn;
    }

    public void Add(Blab blab)
    {
        try
        {
            if (_cmd.Connection.State == ConnectionState.Closed)
                _cmd.Connection.Open();

            _cmd.CommandText = "INSERT INTO " + _srcname +
                               " (sys_id, dttm_created, dttm_modified, content, usr) VALUES" +
                               " (?, ?, ?, ?, ?)";
            _cmd.Parameters.Clear();
            _cmd.Parameters.AddWithValue("param1", blab.Id);
            _cmd.Parameters.AddWithValue("param2", blab.DttmCreated);
            _cmd.Parameters.AddWithValue("param3", blab.DttmModified);
            _cmd.Parameters.AddWithValue("param4", blab.Content);
            _cmd.Parameters.AddWithValue("param5", blab.Username);

            _cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw new Exception(
                "Error " + ex.Number + " has occurred: " + ex.Message
            );
        }
        finally
        {
            _cmd.Connection.Close();
        }
    }

    public IEnumerable<Blab> GetAll()
    {
        if (_cmd.Connection.State == ConnectionState.Closed)
            _cmd.Connection.Open();
        _cmd.CommandText = "SELECT sys_id, dttm_created, dttm_modified, content, usr FROM " + _srcname;

        var reader = _cmd.ExecuteReader();
        List<Blab> buf = new();

        while (reader.Read())
        {
            Blab b = new(reader.GetString(3), reader.GetString(4));
            {
                b.DttmCreated = Convert.ToDateTime(reader.GetString(1));
            }

            buf.Add(b);
        }

        reader.Close();

        return buf;
    }


    public Blab GetById(Guid id)
    {
        try
        {
            if (_cmd.Connection.State == ConnectionState.Closed)
                _cmd.Connection.Open();

            _cmd.CommandText = "SELECT sys_id, dttm_created, dttm_modified, content, usr " +
                               "FROM " + _srcname + " WHERE " + _srcname + ".`sys_id` " +
                               "LIKE '" + id + "'";

            var reader = _cmd.ExecuteReader();

            if (!reader.Read())
            {
                return new Blab("", "");
            }

            Blab res = new(reader.GetString(3), reader.GetString(4))
            {
                Id = reader.GetGuid(0), DttmCreated = reader.GetDateTime(1), DttmModified = reader.GetDateTime(2)
            };

            reader.Close();

            return res;
        }
        catch (MySqlException ex)
        {
            throw new Exception(
                "Error " + ex.Number + " has occurred: " + ex.Message
            );
        }
        finally
        {
            _cmd.Connection.Close();
        }
    }

    public void Update(Blab blab)
    {
        try
        {
            _cmd.Connection.Open();

            _cmd.CommandText = string.Format("UPDATE " + _srcname +
                                             " SET content = '{0}', usr = '{1}', dttm_created = '{2}'," +
                                             " dttm_modified = '{3}' " +
                                             "WHERE id LIKE '{4}'",
                blab.Content, blab.Username, blab.DttmCreated.ToString("yyyy-MM-dd HH:mm:ss"),
                blab.DttmModified.ToString("yyyy-MM-dd HH:mm:ss"), blab.Id);
            // System.Diagnostics.Debug.WriteLine(_cmd.CommandText);
            _cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw new Exception(
                "Error " + ex.Number + " has occurred: " + ex.Message
            );
        }
        finally
        {
            _cmd.Connection.Close();
        }
    }

    public void Remove(Blab blab)
    {
        try
        {
            _cmd.Connection.Open();
            _cmd.CommandText = "DELETE FROM " + _srcname + " WHERE Id LIKE '" + blab.Id + "'";
            // System.Diagnostics.Debug.WriteLine(_cmd.CommandText);
            var reader = _cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw new Exception(
                "Error " + ex.Number + " has occurred: " + ex.Message
            );
        }
        finally
        {
            _cmd.Connection.Close();
        }
    }

    public void RemoveAll()
    {
        try
        {
            if (_cmd.Connection.State == ConnectionState.Closed)
                _cmd.Connection.Open();
            _cmd.CommandText = "TRUNCATE " + _srcname;
            _cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            throw new Exception(
                "Error " + ex.Number + " has occurred: " + ex.Message
            );
        }
        finally
        {
            _cmd.Connection.Close();
        }
    }

    public IEnumerable<Blab> GetByUser(User usr)
    {
        try
        {
            List<Blab> blabs = new List<Blab>();
            _cmd.Connection.Open();
            _cmd.CommandText = "SELECT * FROM " + _srcname + " WHERE Username LIKE '" + usr.Username + "'";

            MySqlDataReader reader = _cmd.ExecuteReader();
            while (reader.Read())
            {
                Blab blab = new Blab("content", "user");
                blab.Id = reader.GetGuid(1);
                blab.Content = reader.GetString(2);
                blab.Username = reader.GetString(3);
                blab.DttmCreated = reader.GetDateTime(4);
                blab.DttmModified = reader.GetDateTime(5);
                blabs.Add(blab);
            }

            return blabs;
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            throw new Exception(
                "Error " + ex.Number + " has occurred: " + ex.Message
            );
        }
        finally
        {
            _cmd.Connection.Close();
        }
    }

    public IEnumerable<Blab> GetAllSortedBy(string colName, string order)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Blab> GetByDateTime(DateTime dttm)
    {
        try
        {
            List<Blab> blabs = new List<Blab>();
            _cmd.Connection.Open();
            _cmd.CommandText = "SELECT * FROM " + _srcname + " WHERE Dttm_created LIKE '" +
                               dttm.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            MySqlDataReader reader = _cmd.ExecuteReader();
            while (reader.Read())
            {
                Blab blab = new Blab("content", "user");
                blab.Id = reader.GetGuid(1);
                blab.Content = reader.GetString(2);
                blab.Username = reader.GetString(3);
                blab.DttmCreated = reader.GetDateTime(4);
                blab.DttmModified = reader.GetDateTime(5);
                blabs.Add(blab);
            }

            return blabs;
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            throw new Exception(
                "Error " + ex.Number + " has occurred: " + ex.Message
            );
        }
        finally
        {
            _cmd.Connection.Close();
        }
    }
}