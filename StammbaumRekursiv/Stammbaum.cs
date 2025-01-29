class Stammbaum
{

    public static Person FindPerson(String NameToFind, Person Root/*, List<string> visitedPersons*/)
    {
       Console.WriteLine(Root.ToString());
       if(NameToFind.Equals(Root.Name))
       {
            return Root;
       }
       //visitedPersons.Add(Root.Name);

       if (Root.Vater != null/* && !visitedPersons.Contains(Root.Vater.Name)*/)
        {
            Person vater = FindPerson(NameToFind, Root.Vater/*visitedPersons*/);
            if (vater != null)
            {
                return vater;
            }
            else if(Root.Mutter != null)
            {
                Person mutter = FindPerson(NameToFind, Root.Mutter/*visitedPersons*/);
                if (mutter != null)
                {
                    return mutter;
                }
            }
            else if(Root.ourChild != null)
            {
                Person child = FindPerson(NameToFind, Root.ourChild/*, visitedPersons*/);
                if (child != null)
                {
                    return child;
                }
            }
        }
       else if(Root.Mutter != null/* && !visitedPersons.Contains(Root.Mutter.Name)*/)
        {
            Person mutter = FindPerson(NameToFind, Root.Mutter/*, visitedPersons*/);
            if (mutter != null)
            {
                return mutter;
            }
            else if(Root.Mutter != null)
            {
                Person vater = FindPerson(NameToFind, Root.Vater/*, visitedPersons*/);
                if (vater != null)
                {
                    return vater;
                }
            }
            else if (Root.ourChild != null)
            {
                Person child = FindPerson(NameToFind, Root.ourChild/*, visitedPersons*/);
                if (child != null)
                {
                    return child;
                }
            }
        }
        else if (Root.ourChild != null)
        {
            Person child = FindPerson(NameToFind, Root.ourChild/*, visitedPersons*/);
            if (child != null)
            {
                return child;
            }
        }


        return null;
    }

    public static void Main(string[] args)
    {
        if(args.Length == 0)
        {
            return;
        }

        string nameToFind = args[0];

        //Begin links
        Person Franz_Bauer = new Person() { Alter = 60, Mutter = null, Vater = null, Name = "Franz Bauer"};
        Person Lisa_Bauer = new Person() { Alter = 50, Mutter = null, Vater = null, Name = "Lisa Bauer" };        
        Person Thomas_Bauer = new Person() { Alter = 30, Mutter = Lisa_Bauer, Vater = Franz_Bauer, Name = "Thomas Bauer" };
        Franz_Bauer.ourChild = Thomas_Bauer;
        Lisa_Bauer.ourChild = Thomas_Bauer;
        //End Links

        //Begin rechts
        Person Karl = new Person() { Alter = 55, Mutter = null, Vater = null, Name = "Karl Mueller" };
        Person Sieghilde = new Person() { Alter = 50, Mutter = null, Vater = null, Name = "Sieghilde Mueller" };
        Person Angie = new Person() { Alter = 32, Mutter = Sieghilde, Vater = Karl, Name = "Angie Bauer" };
        
        Karl.ourChild = Angie;
        Sieghilde.ourChild = Angie;
        //root
        Person Matilda_Bauer = new Person() { Alter = 3, Mutter = Angie, Vater = Thomas_Bauer, Name = "Matilda Bauer" };

        Thomas_Bauer.ourChild = Matilda_Bauer;
        Angie.ourChild = Matilda_Bauer;

        Person found = FindPerson(nameToFind, Sieghilde/*, new List<string>()*/);
        if (found != null)
        { 
            Console.WriteLine(found.ToString() + " wurde gefunden!"); 
        }
        else
        {
            Console.WriteLine("Niemand mit dem Namen " + nameToFind + " wurde gefunden.");
        }

    }
}