
using EF_CF_StudentCourse;

class DBMain
{    
    public static void Main(string[] args)
    {

        Student stud1 = new Student()
        {
            StudentID = 1,
            vorname = "Max",
            nachname = "Mustermann",
            matrNr = "2212345",
            alter = 20,

        };

        Kurs kurse1 = new Kurs()
        {
            KursId = 1,
            Name = "Mathematik",
            ETCS_Points = 4,
            TeacherID = 1,
        };

        stud1.kurse.Add(kurse1);
        kurse1.Students.Add(stud1);

        //stud1.vorname = "Maxiiii"; // Achtung, nicht vergessen - Referenz auf die Liste!!

        using (var db = new StudAndKursRelation())
        {
            db.Students.Add(stud1);

            db.Kurse.Add(kurse1);
            //db.listOfStudKurs.Add(studAKurs1);
            db.SaveChanges();



            var students = from b in db.Students
                               //orderby b.nachname                        
                           select b;
            //or
            var students2 = db.Students;//.OrderBy(b => b.nachname); // auch möglich bedingungen einzubauen - z.B. .Where... nach .listOfStud

            //hol dir die Kurse von nur einem Studenten
            var student3 = db.Students
                       .Where(s => s.nachname.Contains("Muster"))
                       .FirstOrDefault<Student>();
            var kurs = db.Entry(student3)
                .Collection(s => s.kurse)
                .Query(); //.Where(a=>a.id == ......                

            Console.WriteLine("Kurs laden hat funktioniert: " + kurs.FirstOrDefault().Name);

            var student4 = db.Students
                       .Where(s => s.nachname.Contains("Muster"));



            Console.WriteLine("All students in the database:");
            foreach (var stu in students)
            {
                Console.WriteLine(stu.StudentID + " " + stu.vorname + " " + stu.nachname);
                //Console.WriteLine(stu);
                var kursFuerJeden = getKursName(db, stu);
                Console.WriteLine("Dieser Student besucht: " + kursFuerJeden);
            }

            var studentMax = getStudentWithId(1, db);

            studentMax.vorname = "BananaMama";
            db.SaveChanges();

            studentMax = getStudentWithId(1, db);
            Console.WriteLine("Vorname hat sich geändert: " + studentMax.vorname);
            var studentMaxKurs = getKursName(db, studentMax);
            Console.WriteLine("Sein Kurs ist " + studentMaxKurs);




        }
    }

    private static object getKursName(StudAndKursRelation db, Student stu)
    {
        return db.Entry(stu)
                .Collection(s => s.kurse)
                .Query().FirstOrDefault().Name;
    }

    private static Student getStudentWithId(int id, StudAndKursRelation db)
    {
        return (from stud in db.Students
                where stud.StudentID == id
                select stud).First();
    }
}