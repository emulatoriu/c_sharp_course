class EnumExample
{
    enum CountriesInEurope
    {
        Austria,
        Germany,
        Switzerland,
        Netherlands,
        France,
        Portugal,
        Spain,
        Turkey,
        England,
        Scottland,
        Wales,
        Ireland,
        Italy,
        AndManyOthers,
    }

    [Flags] // Das Flags Schlüsselwort macht es möglich Kombinationen von Werten in dem enum zu erstellen
    enum DaysOfAWeek
    {
        //None = 0b_0000_0000,  // 0
        //Monday = 0b_0000_0001,  // 1
        //Tuesday = 0b_0000_0010,  // 2
        //Wednesday = 0b_0000_0100,  // 4
        //Thursday = 0b_0000_1000,  // 8
        //Friday = 0b_0001_0000,  // 16
        //Saturday = 0b_0010_0000,  // 32
        //Sunday = 0b_0100_0000  // 64

        None = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64

    }

    enum TageInDerWoche
    {
        Nichts = 0,
        Montag = 1,
        Dienstag = 2,
        Mittwoch = 4,
        Donnerstag = 8,
        Freitag = 16,
        Samstag = 32,
        Sonntag = 64
    }

    public static void Main(string[] args)
    {
        //Console.BackgroundColor = ConsoleColor.DarkBlue;
        //Console.ForegroundColor = ConsoleColor.White;

        int x = (int)DaysOfAWeek.Monday;

        Console.WriteLine($"My favorite countries are: {CountriesInEurope.Austria}, {CountriesInEurope.Germany}, {CountriesInEurope.France} and {CountriesInEurope.Italy}");
        //Console.WriteLine((CountriesInEurope)0);
        //Console.WriteLine((CountriesInEurope)1);
        //Console.WriteLine((CountriesInEurope)2);
        //Console.WriteLine((CountriesInEurope)3);

        Console.WriteLine((DaysOfAWeek)0);
        Console.WriteLine((TageInDerWoche)((int)DaysOfAWeek.Monday));
        //Console.WriteLine((TageInDerWoche)3);


        DaysOfAWeek OurCourseDays = DaysOfAWeek.Monday | DaysOfAWeek.Wednesday | DaysOfAWeek.Saturday;
        DaysOfAWeek MyFavoriteDays = OurCourseDays;
        Console.WriteLine($"Our course days are {OurCourseDays}, my favorite days are {MyFavoriteDays}");

        foreach(DaysOfAWeek day in Enum.GetValues(typeof(DaysOfAWeek)))
        {
            Console.WriteLine(day);
        }
    }


    //TODO: generische Funktion mit enum???
    private static void genFuncWEnum<T>()
    {

    }
}