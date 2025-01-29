public class MainClass
{
    const int SUDOKU_SIZE = 9;
    const int SUDOKU_SQUARE_SIZE = 3;
    public static bool checkRowSudoku(String[] sudokuArr)
    {
        foreach(String row in sudokuArr)
        {
            String[] rowChars = row.Trim().Split(' ');
            var set = new HashSet<string>(rowChars);
            if(set.Count != SUDOKU_SIZE)
            {
                return false;
            }
        }
        return true;
    }

    public static bool checkColSudoku(String[] sudokuArr)
    {
        List<List<String>> refill = new List<List<String>>();
        for (int i = 0; i < sudokuArr.Count(); i++)
        {
            refill.Add(sudokuArr[i].Trim().Split(' ').ToList());
        }

        for (int i = 0; i < refill.Count(); i++)
        {            
                var set = new HashSet<string>();
                for (int j=0; j< refill[i].Count(); j++)
                {
                    //String[] rowChars = sudokuArr[i].Trim().Split(' ')[0];
                    //set.Add(rowChars[0].ToString());
                    set.Add(refill[j][i]);
                }
            
            if (set.Count != SUDOKU_SIZE)
            {
                return false;
            }
        }
        return true;
    }

    public static bool checkSquareSudoku(String[] sudokuArr)
    {
        int i;
        int j = 0;
        int z = 1;
        for (; z <= SUDOKU_SIZE; z++)
        {
            int runningIndex = (z % SUDOKU_SQUARE_SIZE) * SUDOKU_SQUARE_SIZE;
            for (i = runningIndex; i < runningIndex + SUDOKU_SQUARE_SIZE; i++)
            {
                var set = new HashSet<string>();
                for (j = runningIndex; j < runningIndex + SUDOKU_SQUARE_SIZE; j++)
                {
                    set.Add(sudokuArr[i].Trim().Split(' ')[j-1].ToString());
                }
                if (set.Count != SUDOKU_SIZE)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static void Main(string[] args)
    {
        //      String sudoku = @"5 3 4|6 7 8|9 1 2
        //6 7 2|1 9 5|3 4 8
        //1 9 8|3 4 2|5 6 7
        //8 5 9|7 6 1|4 2 3
        //4 2 6|8 5 3|7 9 1
        //7 1 3|9 2 4|8 5 6
        //9 6 1|5 3 7|2 8 4
        //2 8 7|4 1 9|6 3 5
        //3 4 5|2 8 6|1 7 9";
        String sudoku = @"5 3 4|6 7 8|9 1 2
  6 5 2|1 9 5|3 4 8
  1 9 8|3 4 2|5 6 7
  8 5 9|7 6 1|4 2 3
  4 2 6|8 5 3|7 9 1
  7 1 3|9 2 4|8 5 6
  9 6 1|5 3 7|2 8 4
  2 8 7|4 1 9|6 3 5
  3 4 5|2 8 6|1 7 9";

        sudoku = sudoku.Trim();
        sudoku = sudoku.Replace('|', ' ');
        String[] sudokuArr = sudoku.Split('\n');
        bool checkSudoku = checkSquareSudoku(sudokuArr) && checkRowSudoku(sudokuArr) && checkColSudoku(sudokuArr) ;
        Console.WriteLine(checkSudoku? "Valid Sudoku" : "Invalid Sudoku");
    }
}