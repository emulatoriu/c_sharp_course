using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIFI_Kurs_Teilnehmer
{
    internal class DB_Connect
    {
        static SqlConnection connection;

        public static SqlDataReader makeDBSelectNoWhereWithJoin(string cols, string table, string join)
        {
            string queryString =
            $"SELECT {cols} FROM {table} {join}";
            SqlCommand command = new SqlCommand(queryString, connection);
            return command.ExecuteReader();
        }

        public static SqlDataReader makeDBSelectNoWhere(string cols, string table)
        {
            string queryString =
            $"SELECT {cols} FROM {table} ";
            SqlCommand command = new SqlCommand(queryString, connection);
            SqlDataReader DR = command.ExecuteReader();
            command.Dispose();            
            return DR;
        }

        public static SqlDataReader makeDBSelect(string cols, string table, string whereCond)
        {
            string queryString =
            $"SELECT {cols} FROM {table} "
                + $"WHERE  {whereCond}";
            SqlCommand command = new SqlCommand(queryString, connection);
            return command.ExecuteReader();
        }

        public static void insertKursUTeilnehmer(KursUTeilnehmer kut)
        {
            try
            {
                string insertCmd = "INSERT INTO KursUndTeilnehmer VALUES(@tid, @kid)";

                SqlCommand cmd = new SqlCommand(insertCmd, connection);

                cmd.Parameters.AddWithValue("@tid", kut.TeilnehmerID);
                cmd.Parameters.AddWithValue("@kid", kut.KursID);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void insertKurs(Kurs k)
        {
            try
            {
                string insertCmd = "INSERT INTO Kurs (Kursnamen, Preis) VALUES(@kursname, @preis)";

                SqlCommand cmd = new SqlCommand(insertCmd, connection);

                cmd.Parameters.AddWithValue("@kursname", k.Kursname);
                cmd.Parameters.AddWithValue("@preis", k.Preis);                

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void insertTeilnehmer(Teilnehmer t)
        {
            try
            {
                string insertCmd = "INSERT INTO Teilnehmer (Vorname, Nachname) VALUES(@vorname, @nachname)";

                SqlCommand cmd = new SqlCommand(insertCmd, connection);

                cmd.Parameters.AddWithValue("@vorname", t.VorName);
                cmd.Parameters.AddWithValue("@nachname", t.NachName);
                //cmd.Parameters.AddWithValue("@geburtsdatum", t.dO);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void openDBConnection()
        {
            string connectionString = @"Data Source=MD3I3S6C\SQLEXPRESS;Initial Catalog=WIFIKurs;Integrated Security=True; MultipleActiveResultSets=true";
            //string connectionString = @"Data Source=MD3I3S6C\SQLEXPRESS;Initial Catalog=WIFIKurs;Integrated Security=True;";
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

        public static void closeDBConnection()
        {
            connection.Close();
            connection = null;
        }

    }
}
