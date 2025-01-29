using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableTest.data
{
    internal class Adult : Person
    {
        public String WorksAt { get; set; }
        public Adult(int id, string name, string firstname, int age) 
            : base(id, name, firstname, age)
        {
        }


    }
}
