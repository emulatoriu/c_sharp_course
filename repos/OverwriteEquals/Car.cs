using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace OverwriteEquals
{
    internal class Car
    {
        public String Brand { get; set; }
        public double Price { get; set; }
        public String Color { get; set; }

        public Car(string brand, double price, string color)
        {
            Brand = brand;
            Price = price;
            Color = color;
        }

        public override bool Equals(object? obj)
        {            
            return obj is Car car &&
                   Brand == car.Brand &&                   
                   Color == car.Color;
        }
    }
}
