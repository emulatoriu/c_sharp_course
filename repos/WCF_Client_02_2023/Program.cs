using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Client_02_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WCF_Dienst.IService1 service1 = new WCF_Dienst.Service1Client();
            Console.WriteLine("Please enter your name:");
            String sName = Console.ReadLine();
            String reply = service1.GetData(1);
            //Console.WriteLine(reply);
            WCF_Dienst.CompositeType ct = new WCF_Dienst.CompositeType();
            ct.BoolValue = true;
            ct.StringValue = sName;
            Console.WriteLine(service1.GetDataUsingDataContract(ct).StringValue);
            Console.ReadLine();
        }
    }
}
