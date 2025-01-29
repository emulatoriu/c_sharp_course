class FileIO
{
    public static void Main(string[] args)
    {
        string sPath = @"D:\ConfigFile.txt";

        try
        {
            if (!File.Exists(sPath))
            {
                // Create a file to write to.
                using (StreamWriter sw = new StreamWriter(sPath))
                {
                    sw.WriteLine("Érste Zeile");
                    sw.WriteLine("Zweite Zeile");
                    sw.WriteLine("Dritte Zeile");
                }
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(sPath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}