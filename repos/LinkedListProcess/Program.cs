class MainClass
{
    public static void Main(String[] args)
    {
        LinkedList<InsuranceProcessStep> steps = new();
        steps.AddFirst(new InsuranceProcessStep("Kundendaten aufnehmen"));
        steps.AddLast(new InsuranceProcessStep("Kundendaten eingeben"));
        steps.AddLast(new InsuranceProcessStep("Kundendaten weiterleiten"));
        steps.AddLast(new InsuranceProcessStep("Kundenangebot erstellen"));
        //....
        steps.AddLast(new InsuranceProcessStep("Kundendaten prüfen")); // chef
        steps.AddLast(new InsuranceProcessStep("Vertrag unterschreiben")); // chef
        steps.AddLast(new InsuranceProcessStep("Vertrag returnieren an Mitarbeiter")); // chef
        //....

        foreach (InsuranceProcessStep step in steps)
        {
            if(step.StepDescription.Equals("Kundendaten prüfen"))
            {
                LinkedListNode<InsuranceProcessStep> before = steps.Find(step);
                LinkedListNode<InsuranceProcessStep> checkBefore = new LinkedListNode<InsuranceProcessStep>(new InsuranceProcessStep("Mitarbeiter validiert"));
                steps.AddBefore(before, checkBefore);
                break;
            }
        }
        
        foreach (InsuranceProcessStep step in steps)
        {
            Console.WriteLine(step.StepDescription);
        }


    }
}