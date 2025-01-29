class DicTest
{    
    public static void Main(string[] args)
    {        
        Dictionary<int, string> dic = new Dictionary<int, string>();
        dic.Add(1, "Eins");
        dic.Add(2, "Zwei");
        dic.Add(3, "Drei");
        dic.Add(4, "Vier");
        dic.Add(5, "Fünf");

        String numb = "";

        dic.TryGetValue(3, out numb);

        Console.WriteLine(numb);

        List<string> list = new List<string>();
        list.Add("Das");
        list.Add("ist");
        list.Add("ein");
        list.Add("Test");

        Dictionary<int, string>.Enumerator myDictEnumerator = dic.GetEnumerator();

        
        Dictionary<KeyValuePair<int, int>, string> myDic2 = new();

        myDic2.Add(new KeyValuePair<int, int>(1, 1), "");



        //while (myDictEnumerator.MoveNext())
        //{
        //    //Console.WriteLine(myDictEnumerator.Current);
        //    KeyValuePair<int, string> pair = myDictEnumerator.Current;
        //    Console.WriteLine(pair.Key);
        //}

        for(int i=0; i<dic.Count; i++)
        {
            Console.WriteLine(dic.ElementAt(i).Key);
            Console.WriteLine(dic.ElementAt(i).Value);
        }

        //List<string>.Enumerator myEnumerator = list.GetEnumerator();

        //while (myEnumerator.MoveNext())
        //{
        //    Console.WriteLine(myEnumerator.Current);
        //}


        foreach (KeyValuePair<int, string> pair in dic)
        {
            Console.WriteLine($"key={pair.Key} und value={pair.Value}");
        }
    }
}