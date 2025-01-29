using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternCounter
{
    public class Observer : IObserver
    {
        public void NotifyNameFound(String name)
        {
            Console.WriteLine("Found the name " + name);
        }

        public void Update(int count)
        {
            Console.WriteLine($"{count} reached");
        }

        public void Update2(int count)
        {
            Console.WriteLine($"{count} reached2222");
        }
    }

}
