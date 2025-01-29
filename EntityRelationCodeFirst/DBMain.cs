using EntityRelationCodeFirst;
class DBMain
{
    public static void Main(string[] args)
    {

        Student stud1 = new Student()
        {
            ID = 1,
            vorname = "Max",
            nachname = "Mustermann",
            matrNr = "2212345",
            alter = 20,
            
        };
        
        Kurs kurse1 = new Kurs()
        {
            KursId = 1,
            Name = "Sport",
            ETCS_Points = 4,
            TeacherID = 1,
        };

        stud1.kurse.Add(kurse1);
        kurse1.Students.Add(stud1);

        using (var db = new Bla())
        {
            db.Students.Add(stud1);

            db.Kurse.Add(kurse1);
            //db.listOfStudKurs.Add(studAKurs1);
            db.SaveChanges();


            //var students = from b in db.Students
            //            //orderby b.nachname                        
            //            select b;
            ////or
            //var students2 = db.Students;//.OrderBy(b => b.nachname); // auch möglich bedingungen einzubauen - z.B. .Where... nach .listOfStud

            ////hol dir die Kurse von nur einem Studenten
            //var student3 = db.Students
            //           .Where(s => s.nachname.Contains("Muster"))                    
            //           .FirstOrDefault<Student>();
            //var kurs = db.Entry(student3)
            //    .Collection(s => s.kurse)
            //    .Query(); //.Where(a=>a.id == ......                

            //Console.WriteLine("Kurs laden hat funktioniert: " + kurs.FirstOrDefault().Name);

            //var student4 = db.Students
            //           .Where(s => s.nachname.Contains("Muster"));



            //Console.WriteLine("All students in the database:");
            //foreach (var stu in students)
            //{
            //    Console.WriteLine(stu.ID + " " + stu.vorname + " " + stu.nachname);
            //    //Console.WriteLine(stu);
            //    var kursFuerJeden = db.Entry(stu)
            //    .Collection(s => s.kurse)
            //    .Query();
            //    Console.WriteLine("Dieser Student besucht: " + kursFuerJeden.FirstOrDefault().Name);
            //}

            System.Linq.Expressions.Expression<Func<Student, bool>> filterByNachnameEquals = s => s.nachname.Equals("Mustermann");
            
            Func<Student, bool> filterByAlterGr2 = s => s.alter > 2;

            IEnumerable<Student> students = db.getStudents(filterByAlterGr2);

            foreach(var stu in students)
            {
                Console.WriteLine(stu.nachname);
            }

        }
    }
}