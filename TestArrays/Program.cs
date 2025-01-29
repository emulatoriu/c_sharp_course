using System;

namespace WifiKursApp
{
    public class Program
    {
        private struct mySPecialStruct
        {
            public int meinInt;
            public string meinString;
            public double meinDouble;
        }

        public static void Main(string[] args)
        {
            string[] meineEingelesenenWerte = new string[3];

            Console.Write("Erster Wert: ");
            meineEingelesenenWerte[0] = Console.ReadLine();

            Console.Write("Zweiter Wert: ");
            meineEingelesenenWerte[1] = Console.ReadLine();

            Console.Write("Dritter Wert: ");
            meineEingelesenenWerte[2] = Console.ReadLine();

            for (int i = 0; i < meineEingelesenenWerte.Length; i++)
            {
                Console.WriteLine("Wert " + i + " = " + meineEingelesenenWerte[i]);
            }

            //TODO: sort und das größte ändern
            Console.WriteLine("Bitte sag mir an welcher Stelle ändern:");
            string pos = Console.ReadLine();

            int iPos = 0;
            int.TryParse(pos, out iPos);

            Console.WriteLine("Bitte gib einen neuen Wert ein: ");
            meineEingelesenenWerte[iPos] = Console.ReadLine();

            for (int i = 0; i < meineEingelesenenWerte.Length; i++)
            {
                Console.WriteLine("Wert " + i + " = " + meineEingelesenenWerte[i]);
            }


            //for(int i=0; i<args.Length; i++)
            //{
            //    Console.WriteLine(args[i]);
            //}


            //foreach (string bla in args)
            //{
            //    Console.WriteLine(bla);
            //}

            mySPecialStruct mss = new mySPecialStruct();
            
            int[] myArrInt = new int[] { 2, 4, 6, 8 };


            string[] myArrStr = new string[] { "Ich", "liebe", "Arrays" };
            //Fahrzeuge[] myArrPKWs = new Fahrzeuge[] { pFerrari, fAudi };
            double[] myArrDouble = new double[3]; // ist eine weitere Möglichkeit ein Array zu deklarieren - man reserviert Platz für 3 doubles - Werte sind noch keine drinnen
            
            foreach(string wert in myArrStr)
            {
                Console.WriteLine(wert);
            }
            //List<string> meineStringListe = new List<string> {"Das", "ist", "ein", "schöner", "Satz"};

            //meineStringListe.RemoveAt(2);

            //for(int i=0; i<meineStringListe.Count; i++)
            //{
            //    Console.Write(meineStringListe[i] + " ");
            //}
            //return;
            Console.WriteLine(myArrInt.Length);

            for (int i = 0; i < myArrInt.Length; i++)
            {
                Console.WriteLine(myArrInt[i]);
            }

            int j = 0;
            while (j < myArrStr.Length)
            {
                Console.Write(myArrStr[j] + " ");
                j++;
            }
            Console.WriteLine("");
            //Console.WriteLine(myArrPKWs[0].getsMarke()); // Ferrari
            //Console.WriteLine(myArrPKWs[1].getsMarke()); // Audi
        }
    }
}