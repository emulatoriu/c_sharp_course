class SortArr
{
    public static void Main(string[] args)
    {
        int[] sorted = { 10, 2, 5, 7, 9, 1, 3, 4, 6, 8};
        
        //foreach(var val in sorted)
        //{
        //    Console.WriteLine(val);
        //}

        //Array.Sort(sorted);
        //Array.Reverse(sorted);
        Array.Sort(sorted, delegate(int first, int second)
            {
                if (second < first)
                {
                    return 1;
                }
                else if(second > first)
                {
                    return -1;
                }
                else return 0;
            }
        
        );

        foreach (int val in sorted)
        {
            Console.WriteLine(val);
        }

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        //foreach (var val in sorted)
        //{
        //    Console.WriteLine(val);
        //}

        Object[] stringSorted = { "Alfred", "Programmieren", "Apfel", "Banane", "10", "3", "5", "1", "456" };
        //foreach (var val in stringSorted)
        //{
        //    Console.WriteLine(val);
        //}


        Fahrzeuge fFerrari = new Fahrzeuge();
        fFerrari.iPS = 400;
        fFerrari.sFarbe = "rot";
        fFerrari.sMarke = "Ferrari";

        Fahrzeuge fBMW = new Fahrzeuge();
        fBMW.iPS = fFerrari.iPS;
        fBMW.iPS = 200;
        fBMW.sFarbe = "weiß";
        fBMW.sMarke = "BMW";       

        Fahrzeuge fFord = new Fahrzeuge();
        fFord.iPS = 150;
        fFord.sFarbe = "blau";
        fFord.sMarke = "Ford";

        Fahrzeuge fFiat = new Fahrzeuge();
        fFiat.iPS = 70;
        fFiat.sFarbe = "grün";
        fFiat.sMarke = "Fiat";

        Fahrzeuge[] meineFahrzeuge = new Fahrzeuge[4] { fFerrari, fFord, fBMW, fFiat };

        //Fahrzeuge xy = default(Fahrzeuge);
        
        //meineFahrzeuge[0] = new Fahrzeuge();

        //Fahrzeuge[] meineNeuenFahrzeuge = (Fahrzeuge[])meineFahrzeuge.Clone();        
        //Fahrzeuge[] meineNeuenFahrzeuge = meineFahrzeuge.ToArray();

        //List<Fahrzeuge> fahrZeugListe = meineNeuenFahrzeuge.ToList();

        //fahrZeugListe.Remove(fFerrari);

        Array.Sort(meineFahrzeuge, delegate(Fahrzeuge f1, Fahrzeuge f2)
            {             
                return f2.iPS.CompareTo(f1.iPS);
            }        
        );

        List<Fahrzeuge> fahrzeuges = new List<Fahrzeuge> { fFerrari, fFord, fBMW, fFiat };

            fahrzeuges.Sort(delegate (Fahrzeuge f1, Fahrzeuge f2)
            {
                return f2.iPS.CompareTo(f1.iPS);
            }
        );

        int[] arr1 = new int[5] { 1, 2, 3, 4, 5 };
        int[] arr2 = new int[5] { 1, 2, 3, 4, 6 };

        bool bZahlNichtgefunden = false;
        int iNichtgefunden = -1;

        for (int i= 0; i< arr1.Length; i++)
        {
            for(int j=0; j<arr2.Length; j++)
            {
                if(arr1[i] == arr2[j])
                {
                    break;
                }
                
                if(j == arr2.Length-1)
                {
                    bZahlNichtgefunden=true;
                    iNichtgefunden = arr1[i];
                    break;
                }
            }

            if(bZahlNichtgefunden)
            {
                break;
            }
        }

        if(bZahlNichtgefunden)
        {
            Console.WriteLine("Nicht gefundene Zahl = " + iNichtgefunden);
        }

        //foreach (Fahrzeuge val in meineFahrzeuge)
        //{
        //    Console.WriteLine(val.sMarke);
        //}
        //Array.Sort(stringSorted, delegate(string s1, string s2)
        //    {


        //    }

        //);

        //Console.WriteLine();
        //Console.WriteLine();
        //Console.WriteLine();

        //foreach (var val in stringSorted)
        //{
        //    Console.WriteLine(val);
        //}
    }
}
