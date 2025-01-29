

using SerializeDeserialize;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

class MainClass
{
    //public delegate void output(String str);

    public static void Main(String[] args)
    {

        try
        {
            throw new MyOwnException("Coole Exception", () => Console.WriteLine("Lambda call"));
        }
        catch(MyOwnException e)
        {
            Console.WriteLine(e.Message);
        }

        Action<String> myOutPutFunc;
        if(args.Length > 0 && args[0].Equals("logfile"))
        {
            myOutPutFunc = OutputHelper.printToFile;
        }
        else
        {
            myOutPutFunc = OutputHelper.printToConsole;
        }

        Person p = new Person();
        p.Id = 1;

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(@"D:\person.txt", FileMode.Create, FileAccess.Write);

        formatter.Serialize(stream, p);
        stream.Close();

        Stream readStream = new FileStream(@"D:\person.txt", FileMode.Open, FileAccess.Read);
        Person readP = (Person)formatter.Deserialize(readStream);

        //Console.WriteLine(readP.Id);
        myOutPutFunc(readP.Id.ToString());

        try
        {
            int myNumer = int.Parse(Console.ReadLine());
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            Environment.Exit(1);
            
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            Environment.Exit(1);
            
        }
        finally
        {
            Console.WriteLine("OMG finally ist ja so cool");
        }
        //catch(FormatException fe)
        //{

        //}
        //catch (OverflowException oe)
        //{

        //}
    }
}