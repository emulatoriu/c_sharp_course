// See https://aka.ms/new-console-template for more information
using FahrzeugProjekt;

Console.WriteLine("Hello, World!");

Fahrzeug f = new Fahrzeug();

PKW p = new PKW();




int a = 5;

int b = a;

b = b + 5;

Console.WriteLine(a);
Console.WriteLine(b);

Fahrzeug ferrari = new Fahrzeug();
ferrari.sBrand = "Ferrari";

Fahrzeug porsche = ferrari;
Console.WriteLine(ferrari.sBrand);
Console.WriteLine(porsche.sBrand);

porsche.sBrand = "Porsche";

Console.WriteLine(ferrari.sBrand);
Console.WriteLine(porsche.sBrand);
Console.WriteLine(ferrari.Equals(porsche));

List<Fahrzeug> fahrzeuge = new List<Fahrzeug>();
Fahrzeug fa = new Fahrzeug();
for(int i=0; i<5; i++)
{
    fa.id = i;    
    fahrzeuge.Add(fa);
    fa = new Fahrzeug();
}

foreach (Fahrzeug fah in fahrzeuge)
{
    Console.WriteLine(fah.id);
}