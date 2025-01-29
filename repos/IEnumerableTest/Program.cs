

using IEnumerableTest.data;
using IEnumerableTest.helper;

class MainClass
{ 
    public delegate bool filter(string name);

    public static bool mySpecialFilter(string name)
    {
        return name.StartsWith('A') || name.Length < 6;
    }
    
    public static void Main(string[] args) { 
        List<string> names = new List<string>() { "Dominik", "Tina", "Arsen", "Pascal", "Mario", "Alexander", "Nino", "Thomas" };

        //IEnumerator<string> currentName = names.GetEnumerator();

        //while(currentName.MoveNext())
        //{
        //    Console.WriteLine(currentName.Current);
        //}

        Dictionary<int, string> values = new();

        values.Add(0, "Tina");
        values.Add(1, "Dominik");
        values.Add(2, "Arsen");
        values.Add(3, "Pascal");
        values.Add(4, "Mario");
        values.Add(5, "Alexander");
        values.Add(6, "Nino");
        values.Add(7, "Thomas");

        IEnumerator<KeyValuePair<int, string>> currentName = values.GetEnumerator();

        //while (currentName.MoveNext())
        //{
        //    Console.WriteLine(currentName.Current.Key + ":" + currentName.Current.Value);
        //}

        //foreach(KeyValuePair<int, string> value in values)
        //{
        //    Console.WriteLine(value.Key + ":" + value.Value);
        //}

        //Console.WriteLine(names.Any(name => name.StartsWith('T')));
        //Console.WriteLine(names.Any(name => name.StartsWith('X')));
        Func<string, bool> myFilterFunc = (name) => name.StartsWith('A') || name.Length < 6;

        IEnumerable<string> names2 = names.Where(name => mySpecialFilter(name));
        IEnumerable<string> names3 = names.Where(name => myFilterFunc(name));
        //IEnumerable<string> names2 = from name in names
        //                             where myFilterFunc(name)
        //                             select name;

        //foreach (string name in names2)
        //{
        //    Console.WriteLine(name);
        //}

        IEnumerable<string> firstTwoLetters = names.Select(name => name.Substring(0,2));

        //foreach (string name in firstTwoLetters)
        //{
        //    Console.WriteLine(name);
        //}

        Person adult1 = new Adult(0, "A", "A", 20);
        Person adult2 = new Adult(1, "B", "B", 30);
        Person adult3 = new Adult(2, "C", "C", 40);
        Person adult4 = new Adult(3, "D", "D", 50);

        Person child1 = new Child(4, "x", "x", 3);
        Person child2 = new Child(5, "b", "b", 6);
        Person child3 = new Child(6, "y", "y", 9);
        Person child4 = new Child(7, "d", "d", 12);

        List<Person> persons = new List<Person>();

        persons.Add(adult1);
        persons.Add(adult2);
        persons.Add(adult3);
        persons.Add(adult4);
        persons.Add(child1);
        persons.Add(child2);
        persons.Add(child3);
        persons.Add(child4);

        IEnumerable<string> namesOfChildren = new PersonHelper().getChildsFirstName(persons);

        foreach (String childName in namesOfChildren)
        {
            Console.WriteLine(childName);
        }


        List<int> test = new();        
    }


}