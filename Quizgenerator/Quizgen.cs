class Question
{
    public int ID { get; init; }
    public string question { get; init; }

    public  List<Answer> Possible_Answers { get; set; } = new();


    public Answer RightAnswer
    {
        get
        {
            for (int i = 0; i < Possible_Answers.Count; i++)
            {
                if (Possible_Answers[i].IsCorrect)
                {
                    return Possible_Answers[i];
                }
            }
            return null;
        }
    }


    public Question(string Question, ref int ID)
    {

        this.ID = ID;
        ID = ID++;
        this.question = Question;
        this.Possible_Answers = Possible_Answers;
    }

    //public void addAnswerToQuestions(Answer ans, bool isCorrect)
    //{
    //    if(isCorrect)
    //    {
    //        RightAnswer = ans;
    //    }
    //    Possible_Answers.Add(ans);
    //}

    //public Answer getAnswerAtPos(int pos)
    //{
    //    return Possible_Answers[pos];
    //}

}

class Answer
{
    public int AnswerId { get; init; }
    //public List<int> QuestionId { get; init; }
    public string Text { get; init; }
    public bool IsCorrect { get; init; }
}
class Quizgen
{

    public static void Main(string[] args)
    {
        // Liste mit Fragen
        /*         
        Klasse Fragen
        {
	        idFrage
	        List liste_mit_antworten
	        String Frage;

        } ---------------------------------------------------------- haben wir

        Klass Antwort
        {
	        int idAntwort
	        int idZuWelcherFrage
	        String antw
	        bool richitg_falsch	

        } ---------------------------------------------------------- haben wir        
        */

        // -->dann main
        // erstelle Fragen --> in eine Liste die in der Main ist
        // erstelle meine Antworten
        // Ordne Antworten zu Frage
        // Starte das Quiz

        //ERWEITERUNG: Lies die Fragen und Antworten aus einem File ein!!!

        int idCounter = 0;
        Question question1 = new Question("Wie viel ist 1+1?", ref idCounter);
        Answer answ1_q1 = new Answer() { AnswerId = 0, IsCorrect = true, Text="2"};

        question1.Possible_Answers.Add(answ1_q1);

        // gibt ein Antwort a
        // if(text von Antwort a.Equals(RightAnswer.Text)) ==> richtige Antwort ==> yeah


    }
}