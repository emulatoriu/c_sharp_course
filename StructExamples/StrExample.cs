using System;

class StrExample
{
    private struct MyTime
    {
        public MyTime(int hour, int minutes, int seconds)
        {
            if(hour < 0 || hour > 24 || minutes < 0 || minutes > 59 || seconds < 0 || seconds > 60)
            {
                throw new FormatException("usage: 0<= hour <= 24, 0 <= minutes <= 59, 0 <= seconds <= 59");
            }
            H = hour;
            M = minutes;
            S = seconds;
        }
        public int H { get; set; }
        public int M { get; set; }
        public int S { get; set; }

        public override string ToString() => $"{H}:{M}:{S}"; // mit override überschreibe ich die Funktion ToString von der Klasse System.Object

    }

    // Das ist eine struct deren Attribute nur initialisiert und nicht mehr
    // verändert werden können.
    private readonly struct MyNowTimeMinusXMinutes
    {
        public MyNowTimeMinusXMinutes(int minutesToReduce)
        {
            DateTime original = DateTime.Now;
            DateTime updated = original.Add(new TimeSpan(0, -minutesToReduce, 0));
            H = updated.Hour;
            M = updated.Minute;
            S = updated.Second;
        }
        public int H { get; init; }
        public int M { get; init; }
        public int S { get; init; }

        public override string ToString() => $"{H}:{M}:{S}";
    }

    public static void Main(string[] args)
    {
        MyTime myT = new MyTime(3,23,40);
        Console.WriteLine(myT.ToString());

        MyNowTimeMinusXMinutes mnt = new MyNowTimeMinusXMinutes(15);
        Console.WriteLine(mnt.ToString());

        // Mit with erzeuge ich eine neue Variable vom Typ MyNowTimeMinusXMinutes
        // als Kopie von der bereits existierenden Variable mnt, nur mit einem anderen
        // Wert für die Stunde. Hierbei wird die gleiche Syntax verwendet wie bei der
        // Objektinitialisierung. Hätte H in MyNowTimeMinusXMinutes keinen init-
        // Accessor könnte man H auch nicht über die Objektinitialisierung initialisieren
        MyNowTimeMinusXMinutes mnt2 = mnt with { H = (mnt.H + 12) % 12 };
        Console.WriteLine(mnt2.ToString());
    }
}