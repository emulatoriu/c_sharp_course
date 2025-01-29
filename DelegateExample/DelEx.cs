class DelEx
{
    public delegate void Del(string message);


    public static void MethodWithCallback(int first, int second, Del callback)
    {
        callback("The number is: " + (first + second));
    }

    public static void Main(string[] args)
    {
        // Instantiate the delegate.
        Del handler;
        
        handler = DelegateClass.DelegateMethod;

        // Call the delegate.
        handler("Hello World");

        MethodWithCallback(5, 3, handler);
    }
}

/*
 * Je nach Tageszeit sollen Leute in einer Liste begrüßt werden.
Bis 09:00 Uhr ist es „Good morning“, ab 09:00 bis 13:00 Uhr ist es „Good day“ 
von 13:00 Uhr bis 18:00 Uhr „Good afternoon“ und sonst „Good evening“

 * 
 DateTime todayDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 
DateTime.Now.Day, 13, 0, 0); // bis 13:00 Uhr ist Tag

if (DateTime.Now <= todayMorning)
*/