using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableTest.data
{
    internal class Child : Person
    {
        public String GoesToSchoolAt { get; set; }
        public Child(int id, string name, string firstname, int age) 
            : base(id, name, firstname, age)
        {
        }
    }
}
