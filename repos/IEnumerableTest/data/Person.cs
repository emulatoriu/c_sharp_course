using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableTest.data
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public int Age { get; set; }

        public Person(int id, string name, string firstname, int age)
        {
            Id = id;
            Name = name;
            Firstname = firstname;
            Age = age;
        }
    }
}
