
using System.Data;
using System.Data.SqlClient;

class MainClass
{
    static SqlConnection connection;

    public static void Main(String[] args)
    {
        OpenDB();
        //TRWD_DB.insertRest(r);
        SqlDataReader reader = SelectFromDB("FirstName", "Person");
        var enumerable = reader.Cast<IDataRecord>();

        var filtered = from val in enumerable select val["FirstName"];

        while (reader.Read())
        {
            //Console.WriteLine(
            //            $"{reader["ID"].ToString().Trim(' ')}, {reader[1].ToString().Trim(' ')}, {reader[2].ToString().Trim(' ')}");
            Console.WriteLine(
                        $"{reader["FirstName"].ToString().Trim(' ')}");
        }

        closeDB();
    }

    public static void OpenDB()
    {
        //string connectionString =@"Data Source=(localdb)\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";
        string connectionString = @"Data Source=EMU\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        connection =
            new SqlConnection(connectionString);
        
        try
        {
            connection.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }    

    public static void myCoolFunction(out int a)
    {
        a = 1;
        a++;
    }

    // Insert function

    // update function

    // delete function
    public static SqlDataReader SelectFromDB(string cols, string table, string whereCond = "")
    {
        string queryString = whereCond.Equals("") ? 
            $"SELECT {cols} FROM {table}" :
            $"SELECT {cols} FROM {table} "
                + $"WHERE  {whereCond}";
        SqlCommand command = new SqlCommand(queryString, connection);
        return command.ExecuteReader();

    }
    public static void closeDB()
    {
        connection.Close();
        connection = null;
    }
}