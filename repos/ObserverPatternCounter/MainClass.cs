using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternCounter
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            Counter subscriber = new();
            Observer obs1 = new Observer();
            Observer obs2 = new Observer();

            subscriber.RegisterObserver(obs1);
            subscriber.RegisterObserver(obs2);

            subscriber.Count(10);

            for(int i=0; i<100; i++)
            {
                subscriber.StartsWithT();
            }
        }


    }
}
