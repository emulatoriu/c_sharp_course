class LAD
{
    
    // Delegate for greeting persons correctly
    public delegate void greetPersons(List<string> listOfPersons, Func<int, int> timeToHack);

    private static void sayGoodMorning(List<string> listOfPersons, Func<int, int> timeToHack)
    {
        int minHackTime = 0;
        foreach (var person in listOfPersons)
        {            
            ausgabe("Good morning " + person + ". Time to program for " + timeToHack(minHackTime) + " hours.");
        }
    }

    private static void sayGoodAfternoon(List<string> listOfPersons, Func<int, int> timeToHack)
    {
        int minHackTime = 1;
        foreach (var person in listOfPersons)
        {
            ausgabe("Good afternoon " + person + ". Time to program for " + timeToHack(minHackTime) + " hours.");
        }
    }

    private static void sayGoodEvening(List<string> listOfPersons, Func<int, int> timeToHack)
    {
        int minHackTime = 2;
        foreach (var person in listOfPersons)
        {
            ausgabe("Good evening " + person + ". Time to program for " + timeToHack(minHackTime) + " hours.");
        }
    }

    private static void ausgabe(string str) => Console.WriteLine(str);

    //private static int howLongToHack(int x) =>  x += new Random().Next(0, 10);
    private static int howLongToHack(int x)
    {
        x += new Random().Next(0, 10);
        return x;
    }

    public static void Main(string[] args)
    {
        
        List<string> personsToGreet = new List<string>();
        personsToGreet.Add("Yan Sin Trauner");
        personsToGreet.Add("Patrick Primus");
        personsToGreet.Add("Jakob Zink");
        personsToGreet.Add("Daniel Tuna");
        personsToGreet.Add("Daniel Rabenreither");
        DateTime todayMorning = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0);
        DateTime todayAfternoon = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0);

        greetPersons grP;

        if (DateTime.Now <= todayMorning)
        {
            grP = sayGoodMorning;
        }
        else if(DateTime.Now <= todayAfternoon)
        {
            grP = sayGoodAfternoon;
        }
        else
        {
            grP = sayGoodEvening;
        }

        // () weil kein Parameter zu übergeben ist, <int>
        // bedeutet wir haben einen int Rückgabewert
        // bei zum Beispiel <int, int> hätten wir einen
        // int Parameter und einen int Rückgabewert
        Func<int, int> howLongToHack = (x) => 
        { 
            x += new Random().Next(0, 10); 
            return x; 
        }; // Typical Lambda Expressions
        
        ausgabe(howLongToHack(10).ToString());
        grP(personsToGreet, howLongToHack);      
    }
}