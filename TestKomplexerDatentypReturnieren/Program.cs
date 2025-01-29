class Program
{
    private static string[] SplitMyStringToArray(string myString)
    {
        return myString.Split(',');
    }

    /// <summary>
    /// Funktion gibt wert aus
    /// </summary>
    /// <param name="meineAusgabe">Mein Super Parameter</param>
    private static void ausgabe(string meineAusgabe)
    {
        Console.WriteLine(meineAusgabe);
    }

    /// <summary>
    /// Funktion gibt wert verzögert aus
    /// </summary>
    /// <param name="meineAusgabe">Mein Super Parameter</param>
    /// <param name="waitTime">Meine Waiting time</param>
    private static void ausgabe(string meineAusgabe, int waitTime)
    {
        for (int i = 0; i < meineAusgabe.Length; i++)
        {
            Console.Write(meineAusgabe.ElementAt(i));
            Thread.Sleep(waitTime);
        }
        Console.WriteLine();
    }




    public static void Main(string[] args)
    {
        string myGreets = "Hello, Hallo, Privet, Ahlen ua Sahlen, Salamailaikum";

        string[] myGreetArr = SplitMyStringToArray(myGreets);

        foreach (string greets in myGreetArr)
        {
            Console.WriteLine(greets);
        }

        Personen p1 = new Personen();
        Personen p2 = new Personen(300, "Joda", "Jedimeister");

        //ausgabe("Hello World");
        //ausgabe("Hello World", 100);

        List<Object> myList = new List<Object>();

        myList.Add(p1);
        myList.Add(3);
        myList.Add(p2);
        myList.Add("Hallo");

        foreach (var meineVariable in myList)
        {
            
        }

    }


}