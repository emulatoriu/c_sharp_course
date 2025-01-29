using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeDeserialize
{
    internal class MyOwnException : Exception
    {
        public MyOwnException(String msg, Action func) : base(msg)
        {
            func();
        }
    }
}
