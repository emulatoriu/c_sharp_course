
class Personen
{

    int iAlter { get; set; }
    string name { get; set; }
    string Beruf { get; set; }

    public Personen()
    {
        iAlter = 0;
        name = "";
        Beruf = "";
    }
    public Personen(int iAlter, string name, string Beruf)
    {
        this.iAlter = iAlter;
        this.name = name;
        this.Beruf = Beruf;
    }

}

