using System;

public class Person
{
    //private string name;
    //private int age;

    public string Name { get; init; }

    //public int Age { get; } = 3000; // ist wie init mit 3000
    //public int Age { get; set; }

    public DateTime DayOfBirth { get; init; }    

    public int tellMeHowOldIAm()
    {
        //DateTime yearOfBirth = new DateTime(DateTime.Now.Year - DayOfBirth.Year, DateTime.Now.Month - DayOfBirth.Month, DateTime.Now.Day - DayOfBirth.Day);
                
        //int iAge = (DateTime.Now - DayOfBirth).Days/365;
        return (DateTime.Now - DayOfBirth).Days / 365;
        //return yearOfBirth.Year;
    }

    //public void changeAge(int iAge)
    //{
    //    Age = iAge;
    //}

}

public class PersonWithKonstruktorAndReadonly
{

    string sName;
    int sAge;
    public PersonWithKonstruktorAndReadonly(string sName, int sAge)
    {
        this.sAge = sAge;
        this.sName = sName;
    }

    public string Name => sName; // Properties die nur Readonly sind können die Getter wie ein Ausdruck implementiert werden
    public int Age => sAge;
}

public class AlivePerson
{
    bool bIsPersonInPension;
    int iAge;
    

    public string Name
    { get; set; }

    public int Age
    {
        get { return iAge; }
        set
        {
            if(value < 0)
            {
                throw new ArgumentOutOfRangeException(
                   $"{nameof(value)} hat mit {value} ein eindeutig zu niedriges Alter für eine Person.");
            }
            else if(value > 150)
            {
                throw new ArgumentOutOfRangeException(
                   $"{nameof(value)} hat mit {value} ein eindeutig zu hohes Alter für eine Person.");
            }

            iAge = value;

            bIsPersonInPension = true? value > 65 : false ;
            // Das Gleiche wie
            //if(value > 65)
            //{
            //    bIsPersonInPension = true;
            //}
            //else
            //{
            //    bIsPersonInPension = false;
            //}

        }
    }
}

class Properties
{
    static void Main(string[] args)
    {
        //var pers = new Person { Name = "Tut Ench Amun", Age = 3000 };
        //PersonWithKonstruktorAndReadonly persWithConstr = new PersonWithKonstruktorAndReadonly("myName", 50);

        //// Man könnte stattdessen auch folgendes schreiben
        ////var pers = new Person();
        ////pers.Name = "Tut Ench Amun";
        ////pers.Age = 3000;

        //Console.WriteLine($"{pers.Name} ist {pers.Age} Jahre alt.");

        //Console.WriteLine($"{persWithConstr.Name} ist {persWithConstr.Age} Jahre alt.");

        //var firstPersonAlive = new AlivePerson { Name = "Me", Age = 38 };
        //Console.WriteLine($"{firstPersonAlive.Name} ist {firstPersonAlive.Age} Jahre alt.");
        //var secondPersonAlive = new AlivePerson { Name = "Somebody", Age = 90 };
        //Console.WriteLine($"{secondPersonAlive.Name} ist {secondPersonAlive.Age} Jahre alt.");
        //var thirdPersonAlive = new AlivePerson { Name = "Somebody super old", Age = 200 };        


        Person pers = new Person { Name = "Jakob Zink", DayOfBirth = new DateTime(1991, 12, 4) };
        Console.WriteLine($"{pers.Name} ist {pers.tellMeHowOldIAm()} jung");
    }
}