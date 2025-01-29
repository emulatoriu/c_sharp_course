using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionBeispiele
{
    class Personen
    {
        public string Name { get; set; }
        public string FirstName { get; set; }

        public int Age { get; set; }

        public void tellAboutYou()
        {
            Console.WriteLine("Hi, ich bin " + FirstName + " " + Name + " und bin " + Age + " Jahre alt.");
        }
    }
}
