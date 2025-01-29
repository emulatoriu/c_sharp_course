using FahrzeugeWifi;

namespace WifiFahrzeuge
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            //Fahrzeug f = new Fahrzeug("bmw");
            //f.setMarke("Skoda");
            //f.sMarke = "Ducati";
            Fahrzeug a = new Fahrzeug("renault");
            Fahrzeug b = new Fahrzeug("audi");
            Fahrzeug c = new Fahrzeug("Mazda");
            Fahrzeug d = new Fahrzeug();
            d.setMarke("toyota");

            //a.drivenKM = 160000;
            //a.drivenMiles = a.drivenKM/1.6d;
            //d.sMarke = "";

            List <Fahrzeug> meineFahrzeuge = new List<Fahrzeug>();

            meineFahrzeuge.Add(a);
            meineFahrzeuge.Add(b);  
            meineFahrzeuge.Add(c);
            meineFahrzeuge.Add(d);

            foreach (Fahrzeug f in meineFahrzeuge)
            {
                Console.WriteLine(f.getMarke());
            }


            //Console.WriteLine(Marke);
        }
    }
}