using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public class SQLServerHelper
{
    private string ConnectionString
    {
        get
        {
            ConnectionStringSettingsCollection ConnectionStringSetting = ConfigurationManager.ConnectionStrings;
            return ConnectionStringSetting["ConnectionString"].ConnectionString;
        }
    }

    public DataTable Select(SqlCommand commandSql)
    {
        DataTable datTable = null;

        try
        {
            using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
            {
                using (SqlDataAdapter dataAdapterSql = new SqlDataAdapter())
                {
                    dataAdapterSql.SelectCommand = commandSql;
                    dataAdapterSql.SelectCommand.Connection = connectionSql;
                    datTable = new DataTable();
                    dataAdapterSql.Fill(datTable);
                    return datTable;
                }
            }
        }
        finally
        {
            datTable = null;
        }
    }

    public int Insert(SqlCommand commandSql)
    {
        int rowsAffected = 0;
        using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
        {
            using (SqlDataAdapter dataAdapterSql = new SqlDataAdapter())
            {
                dataAdapterSql.InsertCommand = commandSql;
                dataAdapterSql.InsertCommand.Connection = connectionSql;
                dataAdapterSql.InsertCommand.Connection.Open();
                rowsAffected = dataAdapterSql.InsertCommand.ExecuteNonQuery();
            }            
        }
        return rowsAffected;
    }

    public int Update(SqlCommand commandSql)
    {
        int rowsAffected = 0;
        using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
        {       
            using (SqlDataAdapter dataAdapterSql = new SqlDataAdapter())
            {
                dataAdapterSql.UpdateCommand = commandSql;
                dataAdapterSql.UpdateCommand.Connection = connectionSql;
                dataAdapterSql.UpdateCommand.Connection.Open();
                rowsAffected = dataAdapterSql.UpdateCommand.ExecuteNonQuery();
            }            
        }
        return rowsAffected;
    }

    public int Delete(SqlCommand commandSql)
    {
        int rowsAffected = 0;
        using (SqlConnection connectionSql = new SqlConnection(ConnectionString))
        {
            using (SqlDataAdapter dataAdapterSql = new SqlDataAdapter())
            {
                dataAdapterSql.DeleteCommand = commandSql;
                dataAdapterSql.DeleteCommand.Connection = connectionSql;
                dataAdapterSql.DeleteCommand.Connection.Open();
                rowsAffected = dataAdapterSql.DeleteCommand.ExecuteNonQuery();
            }
        }
        return rowsAffected;
    }
}
