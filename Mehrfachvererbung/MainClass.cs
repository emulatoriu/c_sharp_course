using Mehrfachvererbung;
class MainClass
{
    private static void fortschritt(int seconds)
    {
        string line = "-";
        for (int i = seconds; i > 0; i--)
        {
            Console.Write("\r{0}s {1}  ", i, line);
            line += "-";
            Thread.Sleep(1000);
        }
        Console.WriteLine(line);
    }
    public static void Main(string[] args)
    {
        IPerson derGrinch = new Arbeitslos("Grinch", "Der", 30, Utilities.Gender.male,
            "12345", 12345.6, new DateTime(2000, 1, 1, 0, 0, 0));

        Console.WriteLine($"{derGrinch.Vorname} {derGrinch.Name} ist seit {((IArbeitslos)derGrinch).arbeitslosSeit.ToString()} leider arbeitslos");

        fortschritt(10);

        Console.WriteLine($"Hey {derGrinch.Vorname} {derGrinch.Name} hat einen Job gefunden!");

        derGrinch = new Angestellter("Grinch", "Der", 30, Utilities.Gender.male, "12345", "Nordpol", "Weihnachtsmann", 1000000);

        Console.WriteLine($"Er arbeitet jetzt als {((IAngestellter)derGrinch).AngestelltAls} und verdient dabei {((IAngestellter)derGrinch).JahresEinkommen} Dankeschöns im Jahr.");

        fortschritt(10);

        Console.WriteLine($"Nun hat {derGrinch.Vorname} {derGrinch.Name} auch noch angefangen zu studieren.");

        derGrinch = new AngestelltUndStud("Grinch", "Der", 30, Utilities.Gender.male, "12345", "Uni Nordpol", "Motivationstrainer", new DateTime(2002, 1,1,0,0,0), 1);

        Console.WriteLine($"{derGrinch.Vorname} {derGrinch.Name} macht nun die Ausbildung zum {((AngestelltUndStud)derGrinch).Studienrichtung} an der {((AngestelltUndStud)derGrinch).UniName}");
    }
}