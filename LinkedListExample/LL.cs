class LL
{
    public static void Main(string[] args)
    {
        LinkedList<int> myNumbers = new LinkedList<int>();
        myNumbers.AddLast(0);
        myNumbers.AddLast(2);
        myNumbers.AddLast(3);
        myNumbers.AddLast(4);
        myNumbers.AddLast(5);
        //myNumbers.Append(6);
        LinkedListNode<int> head = myNumbers.First;
        //myNumbers.AddBefore(head, 0);
        LinkedListNode<int> afterHead = new LinkedListNode<int>(1);
        myNumbers.AddAfter(head, afterHead);

        //head.Value = -1; // was würde diese Zeile dann an der Ausgabe verändern

        foreach (int i in myNumbers)
        {
            Console.WriteLine(i);
        }

        //List<int> filtered = myNumbers.Where(n=>n<5).ToList();
        //var filtered = (from value in myNumbers
        //                     where value < 5
        //                     select value);

        //foreach (int i in filtered)
        //{
        //    Console.WriteLine(i);
        //}
    }
}
