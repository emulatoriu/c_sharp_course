using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrzeugProjekt
{
    internal class Fahrzeug
    {
        public String sBrand;
        public double dHP;
        public double dKW;
        public String sFuelType;
        public double dPrice;
        public int id;

        protected void startEngine()
        {
            Console.WriteLine("Wrooooooooooam");
        }
    }
}
