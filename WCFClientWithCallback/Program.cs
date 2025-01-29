using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFClientWithCallback.ServiceReference2;

namespace WCFClientWithCallback
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Construct InstanceContext to handle messages on callback interface
            InstanceContext instanceContext = new InstanceContext(new CallbackHandler());

            // Create a client
            CalculatorDuplexClient client = new CalculatorDuplexClient(instanceContext);

            client.AddTo(5);
            //Console.ReadLine();
            client.AddTo(15);
            Console.ReadLine();
        }

        private class CallbackHandler : ICalculatorDuplexCallback
        {
            public CallbackHandler()
            {
            }
            public void Equals(double result)
            {
                //Console.WriteLine("Equals({0})", result);

                int i = 27;
                Console.WriteLine(i*result);
            }

            public void Equation(string eqn)
            {
                Console.WriteLine("Equation({0})", eqn);
            }
        }
    }
}
