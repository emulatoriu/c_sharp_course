using System.Text.RegularExpressions;

class mClass
{
    static void Main(string[] args)
    {
        while (true)
        {
            // Wir aktzeptieren nur Regex die mindestens 1 Zahl und einen Buchstaben
            // und mindestens 8 Zeichen
            string Eingabe = Console.ReadLine();
            //[^a-zA-Z0-9]+[a-zA-Z]+[0-9]+
            bool match = Regex.Match(Eingabe, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$").Success;

            if (match)
            {
                Console.WriteLine($"Deine Eingabe {Eingabe} entspricht der Regex");
            }
            else
            {
                Console.WriteLine($"Die Eingabe entspricht nicht der Regex");
            }
        }
    }
}