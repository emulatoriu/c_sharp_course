namespace CodeFirstSchool
{
    class MainClass
    {


        static void Main(string[] args)
        {
            Schueler schueler = new Schueler() { age=14, FirstName="Max", LastName="Muster", ID=1};
            Lehrer lehrer = new Lehrer() { age=34, email="bla@bla", Firstname="Peter", Lastname="Hase"};

            schueler.allTeacher.Add(lehrer);
            lehrer.alleStudents.Add(schueler);

            using (var db = new SchuelerLehrerContext())
            {
                db.Lehrers.Add(lehrer);
                db.Schuelers.Add(schueler);

                db.SaveChanges();
            }
        }
    }

}