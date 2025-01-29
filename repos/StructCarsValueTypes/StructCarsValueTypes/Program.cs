class MainClass
{
    //record car (string brand, string color);
    class car
    {
        public string brand { get; set; }
        public string color { get; set; }

        public override String ToString() => $"{brand}, {color}";


        public car(string brand, string color)
        {
            this.brand = brand;
            this.color = color;
        }

    }
    public static void Main(String[] args)
    {
        car car = new car("volvo", "white");
        car car2 = new car("volvo", "white");

        Console.WriteLine(car);

        //car.brand = "";

        //volvo.brand = "volvo";        

        //Console.WriteLine("Skoda brand: " + skoda.brand);

        //car ferrari = skoda with { brand = "ferrari" };
        //car c = new car();
        ////c.Print();
        //for (int i = 0; i < 5; i++)
        //{
        //    c.brand = "megabrand" + i;
        //    c.color = "megacolor" + i;
        //    cars.Add(c);
        //}

        //foreach (car ca in cars)
        //{
        //    Console.WriteLine(ca.brand);
        //    Console.WriteLine(ca.color);
        //}



        //car c = new();
        //List<car> cars = new List<car>();
        //for(int i=0; i<10; i++)
        //{
        //    c.color = "zufällige Farbe";
        //    c.brand = "zufällige brand";
        //    cars.Add(c);
        //}

        //for loop cars ausgeben

    }
}