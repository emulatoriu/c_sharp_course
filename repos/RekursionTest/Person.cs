using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RekursionTest
{
    internal class Person
    {
        public String Name { get; set; }
        public int Age { get; set; }

        public Person leftChild { get; set; }
        public Person rightChild { get; set; }

        public Person(String name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
