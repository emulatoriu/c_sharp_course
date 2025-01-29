using System;

using System.Collections.Generic;
namespace CollectionBeispiele
{
    class MyCollection
    {
        public static void Main(string[] args)
        {
            List<string> beruehmteFernsehZitate = new List<string>();

            beruehmteFernsehZitate.Add("Ich bin dein Vater");
            beruehmteFernsehZitate.Add("Jippie ai ej Schweinebacke");
            beruehmteFernsehZitate.Add("Ich komme wieder");
            beruehmteFernsehZitate.Add("War ich das etwa?");

            for (int i = 0; i < beruehmteFernsehZitate.Count; i++)
            {
                Console.WriteLine(beruehmteFernsehZitate[i]);
            }

            // Test References in Lists
            List<Personen> myPers = new List<Personen>();

            Personen pers1 = new Personen();
            pers1.Age = 30;
            pers1.Name = "Pers1";
            pers1.FirstName = "Pers1";

            myPers.Add(pers1);

            pers1.Age = 40;
            pers1.Name = "Pers2";
            pers1.FirstName = "Pers2";
            myPers.Add(pers1);
            Console.WriteLine();
            Console.WriteLine();
            // which persons does the list contain now?
            foreach (Personen person in myPers)
            {
                person.tellAboutYou();
            }
            Console.WriteLine();
            Console.WriteLine("Man muss das Objekt immer neu instanzieren bevor man es in der Liste speichert oder ein neues Objekt anlegen");
            Console.WriteLine();
            pers1 = new Personen();
            // oder 
            Personen pers2 = new Personen();

            pers1.Age = 50;
            pers1.Name = "Pers3";
            pers1.FirstName = "Pers3";
            myPers.Add(pers1);

            pers2.Age = 60;
            pers2.Name = "Pers4";
            pers2.FirstName = "Pers4";
            myPers.Add(pers2);
            
            foreach (Personen person in myPers)
            {
                person.tellAboutYou();
            }
        }
    }
}