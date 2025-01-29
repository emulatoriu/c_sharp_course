class DR
{
    public delegate int greetPeopleByTime(List<string> ListOfPeople); // muss den gleichen RÜckgabewert haben und die gleichen Paramter wie die FUnktionen auf die es zeigt

    private static int sayGoodMorning(List<string> peopleToSayGoodMorning)
    {
        int iPersonNameLengths = 0;
        foreach (string person in peopleToSayGoodMorning)
        {
            Console.WriteLine($"Good morning {person}");
            iPersonNameLengths += person.Length;
        }
        return iPersonNameLengths;
    }

    private static int sayGoodDay(List<string> peopleToSayGoodMorning)
    {
        int iPersonNameLengths = 0;
        foreach (string person in peopleToSayGoodMorning)
        {
            Console.WriteLine($"Good day {person}");
            iPersonNameLengths += person.Length;
        }
        return iPersonNameLengths;
    }

    private static int sayGoodAfternoon(List<string> peopleToSayGoodMorning)
    {
        int iPersonNameLengths = 0;
        foreach (string person in peopleToSayGoodMorning)
        {
            Console.WriteLine($"Good afternoon {person}");
            iPersonNameLengths += person.Length;
        }
        return iPersonNameLengths;
    }

    private static int sayGoodEvening(List<string> peopleToSayGoodMorning)
    {
        int iPersonNameLengths = 0;
        foreach (string person in peopleToSayGoodMorning)
        {
            Console.WriteLine($"Good evening {person}");
            iPersonNameLengths += person.Length;
        }
        return iPersonNameLengths;
    }

    private static void ausgabeFuerBegruessung(greetPeopleByTime gr, List<string> peopleToGreet)
    {
        peopleToGreet.Add("Emad Easa");
        int strLengthPersons = gr(peopleToGreet);

        Console.Write(strLengthPersons);
    }

    public static void Main(string[] args)
    {
        DateTime todayMorning = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0); // bis 09:00 Uhr ist Morgen
        DateTime todayDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0); // bis 13:00 Uhr ist Tag
        DateTime todayAfternoon = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0); // bis 18:00 is Nachmittag

        //TimeOnly.FromDateTime(DateTime.Now);

        greetPeopleByTime gPBT;
        List<string> peopleToGreet = new List<string>();

        peopleToGreet.Add("Ya Sin Trauner");
        peopleToGreet.Add("Patrick Primus");
        peopleToGreet.Add("Jakob Zink");
        peopleToGreet.Add("Daniel Tuma");
        peopleToGreet.Add("Daniel Rabenreither");


        if (DateTime.Now <= todayMorning)
        {
            gPBT = sayGoodMorning;            
        }
        else if(DateTime.Now <= todayDay)
        {
            gPBT = sayGoodDay;
        }
        else if (DateTime.Now <= todayAfternoon)
        {
            gPBT = sayGoodAfternoon;
        }
        else
        {
            gPBT = sayGoodEvening;
        }

        peopleToGreet.Sort();

        //gPBT(peopleToGreet);
        ausgabeFuerBegruessung(gPBT, peopleToGreet);

        ausgabeFuerBegruessung(sayGoodMorning, peopleToGreet);
    }

}