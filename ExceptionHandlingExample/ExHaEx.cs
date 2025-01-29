class ExHaEx
{
    private static double divide(int divident, int divisor)
    {
        return divident/divisor;
    }
    public static void Main(string[] args)
    {
        string sFile = "varfile.txt";
        bool bDivisionWorked = true;
        double result = 0;
        try
        {
            if (!File.Exists(sFile))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(sFile))
                {
                    sw.WriteLine("1");
                    sw.WriteLine("0");
                }
            }


            // Open the file to read from.
            using (StreamReader sr = File.OpenText(sFile))
            {
                string s;
                int readCounter = 0;
                int iDivident;
                int iDivisor;

                string readLines = "";
                // read only first two lines
                while ((s = sr.ReadLine()) != null)
                {
                    
                    readLines += s + ",";
                    readCounter++;

                    if (readCounter == 2)
                    {
                        break;
                    }
                }

                string[] readLinesArr = readLines.Split(',');
                
                iDivident = Int32.Parse(readLinesArr[0]);
                iDivisor = Int32.Parse(readLinesArr[1]);

                if (iDivident<0)
                {
                    throw new IDontLikeThisValueException("I do not like negative values for divident: ", iDivident);
                }
                else if(iDivisor<0)
                {
                    throw new IDontLikeThisValueException("I do not like negative values for divisor: ", iDivisor);
                }

                result = divide(iDivident, iDivisor);
            }
        }
        catch(IDontLikeThisValueException idltvex)
        {
            Console.WriteLine(idltvex.Message + idltvex.valueIDoNotLike);
            bDivisionWorked = false;
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine("It is not possible to access the file " + sFile + ". " + uae.Message);
            bDivisionWorked = false;
        }
        catch (PathTooLongException ptlex)
        {
            Console.WriteLine("The path " + sFile + " is too long. " + ptlex.Message);
            bDivisionWorked = false;
        }
        catch (DirectoryNotFoundException dnfex)
        {
            Console.WriteLine("The specified directory " + sFile + " was not found. " + dnfex.Message);
            bDivisionWorked = false;
        }
        catch (FileNotFoundException fnfex)
        {
            Console.WriteLine("Could not find the file " + sFile + ". " + fnfex.Message);
            bDivisionWorked = false;
        }
        catch (ArgumentNullException anex)
        {
            Console.WriteLine("You did not pass any file! " + anex.Message);
            bDivisionWorked = false;
        }
        catch (FormatException fe)
        {
            Console.WriteLine("The Values in the file need to be numbers! " + fe.Message);
            bDivisionWorked = false;
        }
        catch (DivideByZeroException dbze)
        {
            Console.WriteLine("The second value in the file should not be 0! " + dbze.Message);
            bDivisionWorked = false;
            return;
        }
        //catch(Exception e)
        //{
        //    switch(e.GetType())
        //    {
        //        case typeof(DivideByZeroException):
        //            Console.WriteLine("The second value in the file should not be 0! " + e.Message);
        //            bDivisionWorked = false;
        //            break;
        //        default:
        //            break;
        //    }   

        //}
        finally
        {
            if (bDivisionWorked)
            {
                Console.WriteLine("The result is " + result);
            }
            else
            {
                Console.WriteLine("Please use only a correct file with correct parameters.");
                Environment.Exit(1);
            }            
        }



        Console.WriteLine("Programm wurde erfolgreich beendet!");

    }
}