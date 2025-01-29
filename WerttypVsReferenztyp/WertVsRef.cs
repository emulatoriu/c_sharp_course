class WertVsRef
{
    public class Auto
    {
        public string Marke { get; set; }
        public string Farbe { get; set; }
        public int PS { get; set; }

        public override string ToString() => $"Marke: {Marke}, Farbe: {Farbe}, PS: {PS}";


    }

    struct strAuto
    {
        public string Marke { get; set; }
        public string Farbe { get; set; }
        public int PS { get; set; }

        public override string ToString() => $"Marke: {Marke}, Farbe: {Farbe}, PS: {PS}";

    }


    class TestStructProperty
    {
        public strAuto meinAutoStruct{ get; set; }
    }

    public static void Main(string[] args)
    {
        int iWertTyp1 = 10;
        int iWertTyp2 = iWertTyp1;
        Console.WriteLine($"{nameof(iWertTyp1)} = {iWertTyp1}, {nameof(iWertTyp2)}={iWertTyp2}");
        Console.WriteLine($"Nun weisen wir dem {nameof(iWertTyp1)} den Wert 5 zu und schauen ob sich der {nameof(iWertTyp2)} ebenfalls ändert.");
        iWertTyp1 = 5;        
        Console.WriteLine($"{nameof(iWertTyp1)} = {iWertTyp1}, {nameof(iWertTyp2)}={iWertTyp2}");

        Auto roterFerrari = new Auto() {Marke="Ferrari", Farbe="rot", PS=600};
        Auto gelberFerrari = roterFerrari;
        Console.WriteLine("Bevor wir die Farbe des gelben Ferraris ändern, sehen die beiden Autos folgendermaßen aus:\n" +
            $"Roter Ferrari: {roterFerrari.ToString()}, Gelber Ferrari: {gelberFerrari.ToString()}");
        gelberFerrari.Farbe = "gelb";
        Console.WriteLine($"Nun haben wir dem gelben Ferrari die Farbe gelb zugewiesen - Roter Ferrari: {roterFerrari.ToString()}, Gelber Ferrari: {gelberFerrari.ToString()}");

        List<strAuto> autos = new List<strAuto>();
        strAuto a = new strAuto() {Marke = "Ferrari", Farbe = "Weiß", PS = 100 };
        strAuto b = a with {Marke="BMW"};
        for (int i=0; i<3; i++)
        {
            autos.Add(a);
            a = a with { Marke = "Volvo", PS = (i + 2) * 100 };
        }
        //b.Marke = "BMW";
        Console.WriteLine(b);

        foreach(strAuto aut in autos)
        {
            Console.WriteLine(aut);
        }


    }
}