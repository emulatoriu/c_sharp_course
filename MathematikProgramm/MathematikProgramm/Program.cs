using System;

namespace MathematikProgramm
{
    class Program
    {

        //private static int multi(int multiplikant, int multiplikator)
        //{
        //    return multiplikant * multiplikator;
        //}

        private const int myTemp = 0;

        private static void ausgabe(string s)
        {
            Console.WriteLine(s);
        }

        private static void ausgabe(float s)
        {
            Console.WriteLine(s);
        }

        public static void Main(string[] args)
        {
            //MatheFunktionen mf = new MatheFunktionen();            

            float produkt = MatheFunktionen.multi(5, 5);

            produkt = produkt * MatheFunktionen.PI;

            ausgabe(produkt);
            ausgabe(myTemp);
        }
    }
}