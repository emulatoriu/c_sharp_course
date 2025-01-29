using OverwriteEquals;

class MainClass
{
    public static void Main(String[] args)
    {
        Car peugeot = new Car("Peugeot", 30000, "white");
        Car peugeot2 = new Car("Peugeot", 60000, "white");

        Console.WriteLine(peugeot.Equals(null));
    }
}