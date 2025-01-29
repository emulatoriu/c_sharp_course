class MainClass
{

    /*
     Symbol    Value
        I          1
        V          5
        X          10
        L          50
        C          100
        D          500
        M          1,000      
     */

    public static void Main(String[] args)
    {
        Dictionary<String, int> romanMapping = new Dictionary<String, int>();
        romanMapping.Add("I", 1);
        romanMapping.Add("IV", 4);
        romanMapping.Add("V", 5);
        romanMapping.Add("IX", 9);
        romanMapping.Add("X", 10);
        romanMapping.Add("XL", 40);
        romanMapping.Add("IL", 49);        
        romanMapping.Add("L", 50);
        romanMapping.Add("IC", 99);
        romanMapping.Add("C", 100);
        romanMapping.Add("ID", 499);
        romanMapping.Add("D", 500);
        romanMapping.Add("M", 1000);
        
        // Von hinten nach vorne, solange gleiche Zeichen muss nichts subtrahiert werden sondern addiert
        // dann subtrahiert
    }
}