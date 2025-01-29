using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFFirstWifiClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client cl = new ServiceReference1.Service1Client();
            string result = cl.GetData(77777);

            Console.WriteLine("result="+result);
            

            ServiceReference1.CompositeType c = new ServiceReference1.CompositeType();
            c.StringValue = "";// "Hallo Leute - schauts mal da ->";
            c.BoolValue = true;
            c = cl.GetDataUsingDataContract(c);

            Console.WriteLine(c.StringValue);

            Console.ReadLine();
        }
    }

}
