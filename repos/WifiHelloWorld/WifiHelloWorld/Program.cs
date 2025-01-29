using System;

namespace WifiKursApp
{
    public class Program
    {

        private static void manipuliere(string sBleibtSo, ref string sVeraendertSich)
        {
            sBleibtSo = "";
            Console.WriteLine(sBleibtSo + " <-- Hier seht ihr den Wert der Variable sBleibtSo innerhalb dieser Funktion.");
            // Die Schreibweise meineVariable += etwasAnderes ist genau die gleiche Schreibweise wie 
            // meineVariable = meineVariable + etwasAnderes
            sVeraendertSich += " Siehst du?";
            Console.WriteLine(sVeraendertSich + " <-- Hier seht ihr den Wert der Variable sVeraendertSich innerhalb dieser Funktion....");
        }


        public static void Main(string[] args)
        {
            string sStr1 = "Ich werde mich nicht verändern.";
            string sStr2 = "Ich werde mich schon verändern.";

            manipuliere(sStr1, ref sStr2);

            Console.WriteLine(sStr1);
            Console.WriteLine(sStr2);
            Console.WriteLine("... und wie ihr hier seht, hat die Variable auch außerhalb der Funktion manipuliere ihren Wert beibehalten.");


        }
    }
}