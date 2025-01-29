using LambdaDelegateTest;

class MainClass
{

    //delegate double Procedure(double a, double b);
    //public static double add(double a, double b)
    //{
    //    return a + b;
    //}

    //public static double subtract(double a, double b)
    //{
    //    return a - b;
    //}

    //public static double multi(double a, double b)
    //{
    //    return a * b;
    //}

    // Definiere einen Delegate Typ für die Ausgabe, der nichts zurückliefert.
    // Implementiere eine Funktion die diesen Delegate Typen implementiert
    // Definiere einen Delegate Typ für die Manipulation von Strings (Übergabe und Returnwert als String)
    // Implementiere 3 Funktionen, die Strings manipulieren können.
    // In der Main Funktion verwende einerseits deinen definierten Delegate um deine Funktionen zu testen
    // und implementiere deine Funktionen noch einmal als Lambdafunktionen und teste diese ebenfalls.


    public delegate String manipulateString(String str);

    public delegate void printFunction(String str);

    public static String makeItLower(String str)
    {
        return str.ToLower();
    }

    public static void print(String str)
    {
        Console.WriteLine(str);
    }

    public static void Main(string[] args)
    {

        printFunction myOutputFunc = print;
        myOutputFunc("Hi Leute");
        Action<String> myOutputFunc2 = Console.WriteLine;
        myOutputFunc2("Hi Leute");
        Action<String> myOutputFunc3 = (s) => {
            Console.WriteLine(s + " komme von Lambda");
            Console.WriteLine(s + " komme von Lambda");
        };
        myOutputFunc3("Hi Leute");







        manipulateString myFunction = makeItLower;
        Console.WriteLine(myFunction("HALLO WIE GEHTS"));

        Func<String, String> myFunction2 = makeItLower;
        Console.WriteLine(myFunction2("HALLO WIE GEHTS"));

        Func<String, int, String> myFunction3 = (s, number) => s.ToLower() + " " + number;
        Console.WriteLine(myFunction3("HALLO WIE GEHTS", 7));

        manipulateString myFunction4 = (s) => s.ToLower();
        Console.WriteLine(myFunction4("HALLO WIE GEHTS"));




    }
}