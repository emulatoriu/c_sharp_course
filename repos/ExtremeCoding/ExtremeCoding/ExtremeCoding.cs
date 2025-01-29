using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtremeCoding
{
    internal class ExtremeCoding
    {

        // Turn int month into string month
        public String example1(int month)
        {
            string[] months = {"January", "February", "March", "April", "Mai", "June", "July", "August", "Septemeber",
            "October", "November", "December"};
            
            if(month > 0 && month < 13)
            {
                return months[month - 1];
            }
            return "";
        }

        // Get max number of a list
        public int example2(List<int> numbers)
        {
            return numbers.Max(x => x);
        }

        // Get max number of an array
        public int example2(int[] numbers)
        {
            return numbers.Max();
        }

        // Get name inverted
        public string example3(string name)
        {
            string[] nameArr = name.Split(' ');
            Array.Reverse(nameArr);
            return string.Join(' ', nameArr);
        }

        // Count Vokals
        public int example4(String str)
        {
            return str.Count(c => "aeiou".Contains(Char.ToLower(c)));
        }

        // Get coded String
        public string example5(String str)
        {
            return str.ToLower().Replace('a', '4').Replace('e', '3').Replace('s', '5').Replace('o', '0').Replace('i', '1');
        }

        // Get if all characters in one string have the same case
        public bool example6(String str)
        {
            return str.Equals(str.ToLower()) || str.Equals(str.ToUpper());
        }

        // Print recursively a string
        public void example7(string str, int maxTimes)
        {            
            if(maxTimes > 0)
            {
                Console.WriteLine(str);
                example7(str, --maxTimes);
            }
        }

        // Get numbers added starting with a number descendend by 1
        public int example8(int numberToAdd, int currentSum)
        {
            int localSum = currentSum + numberToAdd;
            if(numberToAdd > 0)
            {
                localSum = example8(--numberToAdd, localSum);
            }
            return localSum;
        }

        // Reverse all cases in a string
        public string example9(string str)
        {
            string resultString = "";
            
            foreach(char c in str)
            {
                resultString += char.ToLower(c).Equals(c) ? char.ToUpper(c) : char.ToLower(c);
            }

            return resultString;
        }

        // Get all indices of capital letters
        public List<int> example10(string str)
        {
            List<int> indices = new List<int>();
            for(int i=0; i<str.Length; i++)
            {
                if(char.ToUpper(str[i]).Equals(str[i]))
                { 
                    indices.Add(i);
                }
            }

            return indices;
        }

        // Get middle characters of a string
        public String example11(String str)
        {
            if (str.Length > 1)
            {
                if (str.Length % 2 == 1)
                {
                    return str[(str.Length - 1) / 2].ToString();
                }                

                return str[(str.Length / 2) - 1].ToString() + str[str.Length / 2].ToString();
            }

            return str;
        }

        // Check if word is palindorm
        public bool example12(String str)
        {
            //string[] reverse = str.Split();
            //Array.Reverse(reverse);
            //return string.Join("", reverse).Equals(str);
            return str.ToLower().Reverse().SequenceEqual(str.ToLower());
        }

        // Check if a word is an almost palindrom
        public bool example13(String str)
        {
            int missCounter = 0; // can be maximum 1

            string lower = str.ToLower();

            if(str.Length == 1)
            {
                return true;
            }

            for(int i=0; i <= (lower.Length % 2 == 0? (lower.Length/2)-1 : ((lower.Length-1)/2)-1); i++)
            {
                if(!lower[i].Equals(lower[lower.Length-1-i]))
                {
                    missCounter++;                    
                }              
                
                if(missCounter > 1)
                {
                    return false;
                }
            }

            return true;
        }

        // Make palindrom out of a word
        public String example14(String str)
        {
            if(example12(str))
            {
                return str;
            }

            string[] reverse = str.Split();
            Array.Reverse(reverse);
            return str + string.Join("", reverse);            
        }

        public double faculty(double number)
        {
            double result = 1;
            while(number > 0)
            {
                result *= number--;
            }
            return result;
        }
        // Calculate winning chances
        public double example15(double n, double k)
        {
            return faculty(n)/(faculty(k)*faculty(n-k));
        }

        // Get smallest common divisor
        public int exaample16(int first, int second)
        {
            //TODO: Primzahlen Zerlegung
            for(int i=2; i<first; i++)
            {
                if (first % i == 0 && second % i==0)
                {
                    return i;
                }
            }

            return 1;
        }

        // Get smallest multiple of two numbers
        public int example17(int first, int second)
        {
            for (int i = 2; i < first*second; i++)
            {
                if((first*i)%second == 0) 
                {
                    return first*i;
                }
                else if ((second * i) % first == 0)
                {
                    return second*i;
                }
            }

            return first * second;
        }

        // Check if word contains certain character more than once
        public bool example18(String str)
        {
            
            return str.ToLower().Distinct().Count() == str.Length;
            
            //old version:
            //List<char> containingCharacters = new List<char>();

            //for (int i = 0; i < str.Length; i++)
            //{
            //    if (containingCharacters.Contains(str.ToLower()[i]))
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        containingCharacters.Add(str.ToLower()[i]);
            //    }
            //}

            //return true;
        }


        // Return Date one week later
        public String example19(String date)
        {
            if(DateTime.TryParse(date, out DateTime dateTime))
            {
                return dateTime.AddDays(7).ToString();
            }
            return "";
        }

        public String mapHexRest(int number)
        {
            switch(number)
            {
                case 15:
                    return "F";
                case 14:
                    return "E";
                case 13:
                    return "D";
                case 12:
                    return "C";
                case 11:
                    return "B";
                case 10:
                    return "A";
                default:
                    return number.ToString();

            }
        }

        const int BASE = 16;
        // Transfer number into hex number

        public String example20(int number)
        {            
            int moduloResult = number;
            int divisionResult = number;
            List<String> results = new List<String>();

            //while (number / BASE > BASE)
            while(divisionResult > 0)
            {
                moduloResult = divisionResult % BASE;
                divisionResult /= BASE;
                results.Add(mapHexRest(moduloResult));
                
            }
            results.Reverse();
            return string.Join("", results);
        }


        // Check if number is uban (has a 4 or a hundred or a thousand)
        public bool checkUban(int number)
        {
            if(number.ToString().Contains("4"))
            {
                return false;
            }
            else if(number < 100)
            {
                return true;
            }
            else if(number >= 1000000)
            {
                String numberAsStringArr = number.ToString();
                if(Int32.Parse(numberAsStringArr[numberAsStringArr.Length-3].ToString()) >= 1 ||
                    (Int32.Parse(numberAsStringArr[numberAsStringArr.Length - 4].ToString()) >= 1) ||
                    (Int32.Parse(numberAsStringArr[numberAsStringArr.Length - 5].ToString()) >= 1) ||
                    (Int32.Parse(numberAsStringArr[numberAsStringArr.Length - 6].ToString()) >= 1))
                {
                    return false;
                }
                return true;
                
            }
            else
            {
                return false;
            }
        }
        // Get next number which is a uban

        public int example21(int number)
        {
            if(number >= 1000000)
            {
                number++;
                String numbAsString = number.ToString();
               
                Console.WriteLine(numbAsString.Length + " +++  " + number.ToString());
                while (Int32.Parse(numbAsString[numbAsString.Length - 3].ToString()) >= 1 ||
                    (Int32.Parse(numbAsString[numbAsString.Length - 4].ToString()) >= 1) ||
                    (Int32.Parse(numbAsString[numbAsString.Length - 5].ToString()) >= 1) ||
                    (Int32.Parse(numbAsString[numbAsString.Length - 6].ToString()) >= 1))
                {
                    number++;
                    numbAsString = number.ToString();
                }
                return number;
            }
            else if(number >= 100)
            {
                return 1000000;
            }
            else
            {
                while(number.ToString().Contains("4"))
                {
                    number++;
                }
                return number;
            }
        }

        // Change camel to snake case
        public String example22(String camelCase)
        {
            string snakeStr = "";

            for(int i = 0; i < camelCase.Length; i++)
            {
                if(camelCase[i].ToString().Equals(camelCase[i].ToString().ToUpper()))
                {
                    snakeStr += "_" + camelCase[i].ToString().ToLower();
                }
                else
                {
                    snakeStr += camelCase[i];
                }
            }

            return snakeStr;
        }

        // Check if inequality is true or false
        public bool example23(string unequality)
        {
            int left;
            int right;

            string[] numbers;

            if (unequality.Contains(">"))
            {
                numbers = unequality.Split('>');
                if(int.TryParse(numbers[0].Trim(), out left) && int.TryParse(numbers[1].Trim(), out right))
                {
                    return left > right;
                }
            }
            else if (unequality.Contains("<"))
            {
                numbers = unequality.Split('<');
                if (int.TryParse(numbers[0].Trim(), out left) && int.TryParse(numbers[1].Trim(), out right))
                {
                    return left < right;
                }
            }
            return false;
        }

        // Check if knight eats other knight
        public bool example24(int[,] chessboard)
        {            
            if (chessboard.GetLength(0) == 8 && chessboard.GetLength(1) == 8)
            {
                for(int i=0; i<chessboard.GetLength(0); i++)
                {
                    for (int j = 0; j < chessboard.GetLength(1); j++)
                    {
                        if(chessboard[i,j] == 1)
                        {
                            if(i-2>0)
                            {
                                if((j-1>=0 && chessboard[i-2, j-1] == 1)||
                                    (j+1<chessboard.GetLength(1) && chessboard[i - 2, j + 1] == 1))
                                {
                                    return true;
                                }
                            }
                            if(i+2<chessboard.GetLength(0))
                            {
                                if ((j - 1 >= 0 && chessboard[i + 2, j - 1] == 1) ||
                                    (j + 1 < chessboard.GetLength(1) && chessboard[i + 2, j + 1] == 1))
                                {
                                    return true;
                                }
                            }
                            if(j-2>0)
                            {
                                if ((i - 1 >= 0 && chessboard[i -1, j - 2] == 1) ||
                                    (i + 1 < chessboard.GetLength(0) && chessboard[i + 1, j -2] == 1))
                                {
                                    return true;
                                }
                            }
                            if(j+2<chessboard.GetLength(1))
                            {
                                if ((i - 1 >= 0 && chessboard[i - 1, j + 2] == 1) ||
                                    (i + 1 < chessboard.GetLength(0) && chessboard[i + 1, j + 2] == 1))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                
            }

            return false;
        }

    }



}
