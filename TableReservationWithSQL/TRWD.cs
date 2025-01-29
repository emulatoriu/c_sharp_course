using System.Data.SqlClient;

class TRWD
{ 
    

    public static void Main(string[] args)
    {
        Restaurant r = new Restaurant() { RestaurantName="TestRest", CompanyName = "TestRestComp",
            RestStreet = "Musterstraße",
            AddrHouseNumber = 7,
            AddrDoorNumber = 8,
            postalcode = 1220
        };

        TRWD_DB.OpenDB();
        //TRWD_DB.insertRest(r);
        SqlDataReader reader = TRWD_DB.SelectFromDB("*", "Restaurants", "ResID=2");
        while (reader.Read())
        {
            Console.WriteLine(
                        $"{reader[0].ToString().Trim(' ')}, {reader[1].ToString().Trim(' ')}, {reader[2].ToString().Trim(' ')}");
        }

        TRWD_DB.closeDB();

        
    }



}