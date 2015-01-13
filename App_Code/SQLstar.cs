using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class SQLstar
{

    private SQLstar()
    {
    }

    private static SqlConnection GetConnection(string connection_to_use)
    {
        // this opens a connection based on the passed connection string to use instead of assuming one.
        // connection_to_use better exist in web.config or else.
        SqlConnection DB_connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[connection_to_use].ConnectionString);
        try
        {
            DB_connection.Open();
        }
        catch (Exception the_exception)
        {
            Email.SendException(the_exception, "ERROR: (search) SQLstar.GetConnection(" + connection_to_use + ") failure in search");
            return null;
        }
        return DB_connection;
    }

    public static DataRowCollection GetRecordset(string connection_to_use, string sql_statement)
    {
        SqlConnection DB_connection = SQLstar.GetConnection(connection_to_use);
        if (DB_connection != null)
        {
            SqlCommand DB_command = new SqlCommand(sql_statement, DB_connection);
            SqlDataAdapter DB_adapter = new SqlDataAdapter(DB_command);
            DataTable DB_data_table = new DataTable();
            DB_adapter.Fill(DB_data_table);
            DB_connection.Close();
            if (DB_data_table.Rows.Count != 0)
            {
                return DB_data_table.Rows;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public static DataSet GetDataSet(string connection_to_use, string sql_statement)
    {
        SqlConnection DB_connection = SQLstar.GetConnection(connection_to_use);
        if (DB_connection != null)
        {
            SqlCommand DB_command = new SqlCommand(sql_statement, DB_connection);
            SqlDataAdapter DB_adapter = new SqlDataAdapter(DB_command);
            DataSet DB_data_set = new DataSet();
            DB_adapter.Fill(DB_data_set);
            DB_connection.Close();
            if (DB_data_set != null)
            {
                return DB_data_set;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public static void Execute(string connection_to_use, string sql_statement)
    {
        SqlConnection DB_connection = SQLstar.GetConnection(connection_to_use);
        if (DB_connection != null)
        {
            SqlCommand DB_command = new SqlCommand(sql_statement, DB_connection);
            DB_command.ExecuteNonQuery();
            DB_connection.Close();
        }
    }

    public static bool IsCool(string connection_to_use)
    {
        SqlConnection DB_connection = SQLstar.GetConnection(connection_to_use);
        if (DB_connection != null)
        {
            DB_connection.Close();
            return true;
        }
        else
        {
            return false;
        }
    }

    public static Boolean AlreadyExists(string connection_to_use, string sql_statement)
    {
        if (GetRecordset(connection_to_use, sql_statement) == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // Parameterized Queries to help eliminate majority of SQL-Injection attacks.
    // See: http://msdn.microsoft.com/en-us/library/ms998271.aspx
    /*		
        Instead of:
        GetSiteDS = SQLstar.GetRecordset(("sqlprod_92", "SELECT * FROM table WHERE id = '" +
                Request.QueryString["id"] + "';");
		
        Use this:
        SqlParameter[] sql_params = new SqlParameter[2];
        sql_params[0] = new SqlParameter("@id", SqlDbType.Int);		
        DataSet TestDS = GetDataSet_P( "sqlprod_92", "SELECT * FROM table WHERE id=@id", sql_params);
    */

    public static DataSet GetDataSet_P(string connection_to_use, string sql_statement, SqlParameter[] sql_parameters)
    {
        SqlConnection DB_connection = SQLstar.GetConnection(connection_to_use);
        if (DB_connection != null)
        {
            SqlCommand DB_command = new SqlCommand(sql_statement, DB_connection);

            // Add in the parameters
            foreach (SqlParameter p in sql_parameters)
            {
                DB_command.Parameters.Add(p);
            }

            SqlDataAdapter DB_adapter = new SqlDataAdapter(DB_command);

            DataSet DB_data_set = new DataSet();

            DB_adapter.Fill(DB_data_set);
            DB_connection.Close();

            if (DB_data_set != null)
            {
                return DB_data_set;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }


    /*		
        Instead of:
        GetSiteDS = SQLstar.GetRecordset(("sqlprod_92", "SELECT * FROM table WHERE id = '" +
                Request.QueryString["id"] + "';");
		
        Use this:
        SqlParameter[] sql_params = new SqlParameter[2];
        sql_params[0] = new SqlParameter("@id", SqlDbType.Int);		
        DataRowCollection TestRS = GetRecordSet_P( "sqlprod_92", "SELECT * FROM table WHERE id=@id", sql_params);
    */
    public static DataRowCollection GetRecordset_P(string connection_to_use, string sql_statement, SqlParameter[] sql_parameters)
    {
        SqlConnection DB_connection = SQLstar.GetConnection(connection_to_use);
        if (DB_connection != null)
        {
            SqlCommand DB_command = new SqlCommand(sql_statement, DB_connection);
            // Add in the parameters
            foreach (SqlParameter p in sql_parameters)
            {
                DB_command.Parameters.Add(p);
            }

            SqlDataAdapter DB_adapter = new SqlDataAdapter(DB_command);
            DataTable DB_data_table = new DataTable();
            DB_adapter.Fill(DB_data_table);
            DB_connection.Close();
            if (DB_data_table.Rows.Count != 0)
            {
                return DB_data_table.Rows;
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    /*		
        Instead of:
        GetSiteDS = SQLstar.GetRecordset(("sqlprod_92", "DELETE FROM table WHERE id = '" +
                Request.QueryString["id"] + "';");
		
        Use this:
        SqlParameter[] sql_params = new SqlParameter[2];
        sql_params[0] = new SqlParameter("@id", SqlDbType.Int);		
        Execute_P( "sqlprod_92", "DELETE FROM table WHERE id=@id", sql_params);
    */
    public static void Execute_P(string connection_to_use, string sql_statement, SqlParameter[] sql_parameters)
    {
        SqlConnection DB_connection = SQLstar.GetConnection(connection_to_use);
        if (DB_connection != null)
        {
            SqlCommand DB_command = new SqlCommand(sql_statement, DB_connection);
            foreach (SqlParameter p in sql_parameters)
            {
                DB_command.Parameters.Add(p);
            }
            DB_command.ExecuteNonQuery();
            DB_connection.Close();
        }
    }

    public static void Execute_PV(string connection_to_use, string sql_statement, SqlParameter[] sql_parameters)
    {
        SqlConnection DB_connection = SQLstar.GetConnection(connection_to_use);
        if (DB_connection != null)
        {
            SqlCommand DB_command = new SqlCommand(sql_statement, DB_connection);
            foreach (SqlParameter p in sql_parameters)
            {
                try
                {
                    if (p.Value.ToString() == "")
                    {
                        p.Value = DBNull.Value;
                    }
                }
                catch { }
                DB_command.Parameters.AddWithValue(p.ToString(), p.Value);
            }
            DB_command.ExecuteNonQuery();
            DB_connection.Close();
        }
    }
}
