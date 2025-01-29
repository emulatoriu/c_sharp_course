using AbstractAndVirtual;

class AbstrMain
{
    public static void Main(string[] args)
    {
        Tiger t = new Tiger() { Tierart = "Tiger"};
        Katze k = new Katze() { Tierart = "Katze"};
        

        Console.WriteLine($"Der {t.GetType().Name} macht {t.MachDeinenLaut}");
        Console.WriteLine($"Die {k.GetType().Name} macht {k.MachDeinenLaut}");

    }
}