using System;
using System.Data;
using System.Data.SqlClient;
internal class TRWD_DB
{
    static SqlConnection connection;

    //static string connectionString =
    //        "Data Source=(local);Initial Catalog=TableReservation;"
    //        + "Integrated Security=true";

    public static void insertRest(Restaurant rest)
    {
        String insertCmd = "INSERT INTO Restaurants (RestName, CompanyName," +
            "Reststreet, AddrHouseNumber, AddrDoorNumber, PLZ) VALUES(@resName," +
            "@compName, @restStreet, @HouseNumb, @DoorNumb, @plz)";
        SqlCommand command = new SqlCommand(insertCmd, connection);
        
        //command.Parameters.AddWithValue("@resID", rest.RestaurantID);
        command.Parameters.AddWithValue("@resName", rest.RestaurantName);
        command.Parameters.AddWithValue("@compName", rest.CompanyName);
        command.Parameters.AddWithValue("@restStreet", rest.RestStreet);
        command.Parameters.AddWithValue("@HouseNumb", rest.AddrHouseNumber);
        command.Parameters.AddWithValue("@DoorNumb", rest.AddrDoorNumber);
        command.Parameters.AddWithValue("@plz", rest.postalcode);
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.InsertCommand = command;
        adapter.InsertCommand.ExecuteNonQuery();
        command.Dispose();

    }

    public static SqlDataReader SelectFromDB(string cols, string table, string whereCond)
    {
        //string queryString =
        //    "SELECT * FROM Restaurants "
        //        + "WHERE  ResID=2";
        string queryString =
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

    public static void OpenDB()
    {
        //string connectionString =
        //    "Data Source=(local);Initial Catalog=Northwind;"
        //    + "Integrated Security=true";
        string connectionString =
        //"Data Source=(local);Initial Catalog=TableReservation;"
        //+ "Integrated Security=true";

        @"Data Source=MD3I3S6C\SQLEXPRESS;Initial Catalog=TableReservation;Integrated Security=True";

        // Provide the query string with a parameter placeholder.
        //string queryString =
        //    "SELECT ProductID, UnitPrice, ProductName from dbo.products "
        //        + "WHERE UnitPrice > @pricePoint "
        //        + "ORDER BY UnitPrice DESC;";

        // Specify the parameter value.
        int paramValue = 5;

        // Create and open the connection in a using block. This
        // ensures that all resources will be closed and disposed
        // when the code exits.
        connection =
            new SqlConnection(connectionString);
        // Create the Command and Parameter objects.
        //SqlCommand command = new SqlCommand(queryString, connection);
        //command.Parameters.AddWithValue("@pricePoint", paramValue);

        // Open the connection in a try/catch block.
        // Create and execute the DataReader, writing the result
        // set to the console window.
        try
        {
            connection.Open();            
            //SqlDataReader reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.WriteLine("\t{0}\t{1}\t{2}",
            //        reader[0,], reader[1], reader[2]);
            //}
            //reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
   
        
    }
}
