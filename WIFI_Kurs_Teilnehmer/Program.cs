using System.Data.SqlClient;

namespace WIFI_Kurs_Teilnehmer
{
    class WUKT
    {
        static void Main(string[] args)
        {
            DB_Connect.openDBConnection();

            //DateOnly dO = new DateOnly();
            //dO.AddDays(1);
            //dO.AddMonths(1);
            //dO.AddYears(1990);

            //Teilnehmer t = new Teilnehmer() { VorName="Ya-Sin", NachName="Trauner", dO = dO};

            
            Kurs k = new Kurs() {Kursname="C# Entwickler", Preis=4300};
            DB_Connect.insertKurs(k);

            //DB_Connect.insertTeilnehmer(t);

            SqlDataReader sqlDR = DB_Connect.makeDBSelectNoWhere("*", "Teilnehmer");

            KursUTeilnehmer kut;

            //while (sqlDR.Read())
            //{
            //    // because we iterate through a resultset and in there executing another
            //    // query, we would get the error message "There is already an open DataReader
            //    // associated with this Command which must be closed first." if we did not 
            //    // include in our connection string MultipleActiveResultSets=true
            //    kut = new KursUTeilnehmer() { TeilnehmerID = int.Parse(sqlDR[0].ToString()), KursID = 1 };
            //    DB_Connect.insertKursUTeilnehmer(kut);
            //    Console.WriteLine(
            //                $"{sqlDR[0].ToString().Trim(' ')}, {sqlDR[1].ToString().Trim(' ')}, {sqlDR[2].ToString().Trim(' ')}");
            //}
            
            DB_Connect.closeDBConnection();
            DB_Connect.openDBConnection();

            SqlDataReader sqlWJoin = DB_Connect.makeDBSelectNoWhereWithJoin("*", "Teilnehmer", "INNER JOIN KursUndTeilnehmer on Teilnehmer.ID = KursUndTeilnehmer.TeilnehmerID INNER JOIN Kurs on KursUndTeilnehmer.KursID = Kurs.ID");


            while (sqlWJoin.Read())
            {
                //SELECT * FROM Teilnehmer INNER JOIN KursUndTeilnehmer on Teilnehmer.ID = KursUndTeilnehmer.TeilnehmerID
                Console.WriteLine(
                            $"{sqlWJoin[0].ToString().Trim(' ')}, {sqlWJoin[1].ToString().Trim(' ')}, {sqlWJoin[2].ToString().Trim(' ')}, {sqlWJoin[3].ToString().Trim(' ')}, {sqlWJoin[7].ToString().Trim(' ')}");
            }





            DB_Connect.closeDBConnection();
        }

    }
}