using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Person
    {

        public int Alter { get; set; }
        public string Name { get; set; }

        public Person Vater { get; set; } // left Child

        public Person Mutter { get; set; } // right Child

        public Person ourChild { get; set; }


    public override string ToString()
    {
        return Name;
    }
}

