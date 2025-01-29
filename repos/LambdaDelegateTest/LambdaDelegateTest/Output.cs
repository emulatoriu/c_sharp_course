using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDelegateTest
{
    internal class Output
    {

        Func<string, string> outputFunc;
        
        public Output(Func<string, string> outputFunc)
        {
            this.outputFunc = outputFunc;
        }

        public void print(string strToOutput)
        {
            Console.WriteLine(outputFunc(strToOutput));
        }


    }
}
