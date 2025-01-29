using TestReferenzes;
class Program
{
    public static void Test(Person pers)
    {
        pers.name = "Bla";
    }

    public static void Main()
    {
        Person myPerson = new Person("Test", 40);
        Test(myPerson);
        Console.WriteLine(myPerson.name);
    }
}