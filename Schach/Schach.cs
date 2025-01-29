class Schach
{
    public static List<string> visitedFields = new List<string>();
    // Schachbrett: 8 Reihen und 8 Spalten
    static string[,] brett = new string[8, 8];

    public static void myArrFunc(string[] myarr)
    {
        foreach(string val in myarr)
        {
            Console.WriteLine(val);
        }
    }

    public static bool HorseJump(string startField, int howOftenToJumpMore)
    {

        if (howOftenToJumpMore <= 0) 
        { 
            return true; 
        }
        List<string> futureKnightFields = new List<string>();

        bool bFound = false;

        for (int i = 0; i < brett.GetLength(0); i++)
        {
            for (int j = 0; j < brett.GetLength(1); j++)
            {
                if (brett[i, j].Equals(startField))
                {
                    if (i - 2 >= 0 && j - 1 >= 0) // -2,-1
                    {
                        futureKnightFields.Add(brett[i - 2, j - 1]); // 2 Felder rauf und 1 nach links
                    }
                    if (i - 2 >= 0 && j + 1 <= 7) // -2,+1
                    {
                        futureKnightFields.Add(brett[i - 2, j + 1]); // 2 Felder rauf und 1 nach rechts
                    }
                    if (i - 1 >= 0 && j - 2 <= 7 && j-2 >=0) // -1,-2
                    {
                        futureKnightFields.Add(brett[i - 1, j - 2]); // 2 Felder rauf und 1 nach rechts
                    }
                    if (i - 1 >= 0 && j + 2 <= 7) // -1,+2
                    {
                        futureKnightFields.Add(brett[i - 1, j + 2]); // 2 Felder rauf und 1 nach rechts
                    }
                    if (i + 1 >= 0 && i + 1<=7 && j - 2 <= 7 && j - 2 >= 0) // +1,-2
                    {
                        futureKnightFields.Add(brett[i + 1, j - 2]); // 2 Felder rauf und 1 nach rechts
                    }
                    if (i + 1 >= 0 && i + 1 <= 7 && j + 2 <= 7) // +1,+2
                    {
                        futureKnightFields.Add(brett[i + 1, j + 2]); // 2 Felder rauf und 1 nach rechts
                    }
                    if (i + 2 <= 7 && j - 1 <= 7 && j - 1 >= 0) // +2,-1
                    {
                        futureKnightFields.Add(brett[i + 2, j - 1]); // 2 Felder rauf und 1 nach rechts
                    }
                    if (i + 2 <= 7 &&  j + 1 <= 7) // +2,+1
                    {
                        futureKnightFields.Add(brett[i + 2, j + 1]); // 2 Felder rauf und 1 nach rechts
                    }
                    bFound = true;
                    break;
                }
                if(bFound)
                {
                    break;
                }
            }
        }

        foreach(string field in futureKnightFields)
        {
            if(!visitedFields.Contains(field))
            {
                visitedFields.Add(field);
                if (HorseJump(field, howOftenToJumpMore - 1))
                {                    
                    return true;
                }
                else
                {
                    Console.WriteLine($"Von {field} bin ich nicht mehr weiter gekommen an Stelle {visitedFields.Count-1}");
                    visitedFields.Remove(field);
                }
            }

        }

        return false;
    }

    public static void Main(string[] args)
    {
        
        brett[0, 0] = "a8";
        brett[0, 1] = "b8";
        brett[0, 2] = "c8";
        brett[0, 3] = "d8";
        brett[0, 4] = "e8";
        brett[0, 5] = "f8";
        brett[0, 6] = "g8";
        brett[0, 7] = "h8";

        brett[1, 0] = "a7";
        brett[1, 1] = "b7";
        brett[1, 2] = "c7";
        brett[1, 3] = "d7";
        brett[1, 4] = "e7";
        brett[1, 5] = "f7";
        brett[1, 6] = "g7";
        brett[1, 7] = "h7";

        brett[2, 0] = "a6";
        brett[2, 1] = "b6";
        brett[2, 2] = "c6";
        brett[2, 3] = "d6";
        brett[2, 4] = "e6";
        brett[2, 5] = "f6";
        brett[2, 6] = "g6";
        brett[2, 7] = "h6";

        brett[3, 0] = "a5";
        brett[3, 1] = "b5";
        brett[3, 2] = "c5";
        brett[3, 3] = "d5";
        brett[3, 4] = "e5";
        brett[3, 5] = "f5";
        brett[3, 6] = "g5";
        brett[3, 7] = "h5";

        brett[4, 0] = "a4";
        brett[4, 1] = "b4";
        brett[4, 2] = "c4";
        brett[4, 3] = "d4";
        brett[4, 4] = "e4";
        brett[4, 5] = "f4";
        brett[4, 6] = "g4";
        brett[4, 7] = "h4";

        brett[5, 0] = "a3";
        brett[5, 1] = "b3";
        brett[5, 2] = "c3";
        brett[5, 3] = "d3";
        brett[5, 4] = "e3";
        brett[5, 5] = "f3";
        brett[5, 6] = "g3";
        brett[5, 7] = "h3";

        brett[6, 0] = "a2";
        brett[6, 1] = "b2";
        brett[6, 2] = "c2";
        brett[6, 3] = "d2";
        brett[6, 4] = "e2";
        brett[6, 5] = "f2";
        brett[6, 6] = "g2";
        brett[6, 7] = "h2";

        brett[7, 0] = "a1";
        brett[7, 1] = "b1";
        brett[7, 2] = "c1";
        brett[7, 3] = "d1";
        brett[7, 4] = "e1";
        brett[7, 5] = "f1";
        brett[7, 6] = "g1";
        brett[7, 7] = "h1";

        string knightField = "a1";

        int howManyFields = 60;
        
        Console.WriteLine(knightField);
        if(!HorseJump(knightField, howManyFields))
        {
            Console.WriteLine($"Es war nicht möglich auf {howManyFields} Felder zu springen");
        }

        int i = 0;
        foreach (String fields in visitedFields)
        {
            Console.WriteLine(i + ": " + fields);
            i++;
        }

        //List<string> futureKnightFields = new List<string>();

        //for (int i = 0; i < brett.GetLength(0); i++)
        //{
        //    for (int j = 0; j < brett.GetLength(1); j++)
        //    {
        //        if (brett[i, j].Equals(knightField))
        //        {
        //            if (i - 2 >= 0 && j - 1 >= 0) // -2,-1
        //            {
        //                futureKnightFields.Add(brett[i - 2, j - 1]); // 2 Felder rauf und 1 nach links
        //            }
        //            if (i - 2 >= 0 && j + 1 <= 7) // -2,+1
        //            {
        //                futureKnightFields.Add(brett[i - 2, j + 1]); // 2 Felder rauf und 1 nach rechts
        //            }
        //            if (i - 1 >= 0 && j -2 <= 7) // -1,-2
        //            {
        //                futureKnightFields.Add(brett[i - 1, j - 2]); // 2 Felder rauf und 1 nach rechts
        //            }
        //            if (i - 1 >= 0 && j + 2 <= 7) // -1,+2
        //            {
        //                futureKnightFields.Add(brett[i - 1, j + 2]); // 2 Felder rauf und 1 nach rechts
        //            }
        //            if (i + 1 >= 0 && j - 2 <= 7) // +1,-2
        //            {
        //                futureKnightFields.Add(brett[i + 1, j - 2]); // 2 Felder rauf und 1 nach rechts
        //            }
        //            if (i + 1 >= 0 && j + 2 <= 7) // +1,+2
        //            {
        //                futureKnightFields.Add(brett[i + 1, j + 2]); // 2 Felder rauf und 1 nach rechts
        //            }
        //            if (i + 2 >= 0 && j - 1 <= 7) // +2,-1
        //            {
        //                futureKnightFields.Add(brett[i + 2, j - 1]); // 2 Felder rauf und 1 nach rechts
        //            }
        //            if (i + 2 >= 0 && j + 1 <= 7) // +2,+1
        //            {
        //                futureKnightFields.Add(brett[i + 2, j + 1]); // 2 Felder rauf und 1 nach rechts
        //            }                    
        //        }
        //    }
        //}

        //Erweiterung für alle Figuren!

        //Erweiterung schachbrett ausgabe auf der console und eine Figur ziehen lassen
        // |ST|SS|......
        // |SB|SB|....
        // |__|__...
        // ...
        // |WB|WB

        //foreach (String field in futureKnightFields)
        //{
        //    Console.WriteLine($"Der Springer kann auf das Feld {field} springen");
        //}

    }

}
