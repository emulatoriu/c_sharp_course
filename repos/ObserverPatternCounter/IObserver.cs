using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternCounter
{
    public interface IObserver
    {
       void Update(int count);
        void Update2(int count);
        void NotifyNameFound(String name);
    }
}
