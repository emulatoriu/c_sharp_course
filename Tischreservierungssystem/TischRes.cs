class Table
{
    public int _id { get; init; }
    public int anzPlaetze { get; set; }

    public bool isReserved { get; set; } = false;

    public string name { get; set; }

    public bool isSmoker { get; set; } = false;

    public Table(ref int _id)
    {
        this._id = _id;
        _id++;
    }

    public Table(ref int _id, int anzPlaetze, string name)
    {
        this._id = _id;
        _id++;
        this.anzPlaetze = anzPlaetze;
        this.name = name;
    }

}




class TischRes
{
    public static void Main(string[] args)
    {
        //Klasse Tisch
        //Liste von Tischen -> durchiterieren
        // nur mal schauen ob man den ersten Tisch beim Iterieren reservieren kann

        //Erweiterung - den optimalen Tisch finden, sprich den der mit der niedrigsten Anzahl an freien Plätzen die Reservierung bedient
        // Tipp von Daniel -> vorher Liste sortieren (von den Tischen von niedrigsten Sitzplätzen nach größten) --> Funktion Sort mit delegate :D

        //Erweiterung - aus einer Liste die Tische einlesen

        List<Table> freieTische = new List<Table>();

        int idCounter = 0;

        Table table1 = new Table(ref idCounter, 4, "TischAmFenster");
        Table table2 = new Table(ref idCounter, 2, "TischMitte");

        freieTische.Add(table1);
        freieTische.Add(table2);

        string eingabe = Console.ReadLine();

        int iEingabe = int.Parse(eingabe);

        for(int i=0; i < freieTische.Count; i++)
        {
            if(iEingabe <= freieTische[i].anzPlaetze)
            {
                if(freieTische[i].isReserved == false)
                {
                    freieTische[i].isReserved = true;
                    // und mach eine Ausgabe usw.
                }
            }
        }
    }
}