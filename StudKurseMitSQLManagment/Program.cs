using System.Data.SqlClient;

class StudAndKurs
{

    static SqlConnection connection;
    public void connectDB()
    {
        //connection properties from click in managment studio to properties and then on the bottom connection properties
        string connectionString = @"Data Source = MD3I3S6C\SQLEXPRESS; Initial Catalog = Uni; Integrated Security = True";
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
    static void Main(string[] args)
    {

    }
}