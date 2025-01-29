class LINQO
{
    public static void Main(string[] args)
    {
        int[] marks = { 1, 2, 3, 4, 5 };

        //LINQ expression
        IEnumerable<int> goodMarks = 
            from mark in marks
            where mark <= 3            
            select mark;

        foreach(var elem in goodMarks)
        {
            Console.WriteLine(elem);
        }

        LinkedList<int> badMarks = new LinkedList<int>(marks.Where(m => m>3));
        List<int> badMarks2 = new List<int>(marks.Where(m => m > 3));
        List<int> badMarks3 = marks.Where(m => m > 3).ToList();
        int oneBadMark = badMarks.Where(m => m>3).First();
        int oneBadMarkOrDefault = badMarks.Where(m => m>3).FirstOrDefault(-1);

        foreach (int mark in badMarks)
        {
            Console.WriteLine($"{mark} is a good mark");
        }        


        foreach (int mark in goodMarks)
        {
            Console.WriteLine($"{mark} is a good mark");
        }


        Spieler s1 = new Spieler() { id=1, currentBalance=5000, isStillInGame=true, name="Max", age=50};
        Spieler s2 = new Spieler() { id = 1, currentBalance = 6000, isStillInGame = true, name = "Gertrude", age = 20 };
        Spieler s3 = new Spieler() { id = 1, currentBalance = 2000, isStillInGame = true, name = "Henriette", age = 30 };
        Spieler s4 = new Spieler() { id = 1, currentBalance = 1000, isStillInGame = false, name = "Margit", age = 40 };
        Spieler s5 = new Spieler() { id = 1, currentBalance = 0, isStillInGame = true, name = "Hans", age = 100 };

        List<Spieler> allPlayers= new List<Spieler>() { s1, s2, s3, s4, s5 };

        Console.WriteLine();
        Console.WriteLine();

        IEnumerable<Spieler> activePlayers =
            from p in allPlayers
            where p.isStillInGame == true
            select p;

        IEnumerable<Spieler> NotActivePlayers = allPlayers
            .Where(p => !p.isStillInGame);

        //Dictionary<int, Spieler> JoinedDicOfAllPlayers = allPlayers
        //    .Where(p=>p.currentBalance<=1000).ToDictionary(p=>p.id, p=>p)
        //    .Join(allPlayers, allPlayers.Where(p=>p.currentBalance>=5000).ToDictionary(p=>p.id, p=>p));

        //var joins = activePlayers.Join(NotActivePlayers)


        //Dictionary<int, Spieler> NotActivePlayersDic = allPlayers
        //    .Where(p=>!p.isStillInGame).ToDictionary(p => p.id, p => p);

        foreach(Spieler pl in activePlayers)
        {
            Console.WriteLine($"{pl.name} is still in game");
        }

        Console.WriteLine();
        Console.WriteLine();

        IEnumerable<Spieler> maturePlayersOfActive = activePlayers.Where(p => p.age > 30);

        foreach (Spieler pl in maturePlayersOfActive)
        {
            Console.WriteLine($"{pl.name} is {pl.age} years old");
        }

        Console.WriteLine();
        Console.WriteLine();

        IEnumerable<Spieler> playersWithALotOfMoney =
            from p in allPlayers
            where p.currentBalance > 1000
            select p;

        foreach (Spieler pl in playersWithALotOfMoney)
        {
            Console.WriteLine($"{pl.name} has a lot of money - current balance: {pl.currentBalance}");
        }
    }
}