using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Create a new instance of the Counter class
        Counter counter = new Counter();

        // Create two new instances of the Observer class
        Observer observer1 = new Observer("Observer 1");
        Observer observer2 = new Observer("Observer 2");

        // Register the observer objects with the Counter object
        counter.CountReached += (sender, e) => observer1.Update(sender, e, nameof(observer1));
        counter.CountReached += observer1.Update2;
        counter.CountReached += (sender, e) => observer2.Update(sender, e, nameof(observer2));

        // Call the Count method on the Counter object
        counter.Count(5);
    }
}

public class Counter
{
    // Define an event called CountReached
    public event EventHandler CountReached;

    // Define a method called Count that raises the CountReached event when the count reaches a specified number
    public void Count(int maxCount)
    {
        for (int count = 1; count <= maxCount; count++)
        {
            Console.WriteLine("Count: " + count);            
        }
        OnCountReached();
    }

    // Define a method called OnCountReached that raises the CountReached event
    protected virtual void OnCountReached()
    {
        if (CountReached != null)
        {
            CountReached(this, EventArgs.Empty);
        }
    }
}

public class Observer
{
    private string name;

    public Observer(string name)
    {
        this.name = name;
    }

    // Define a method called Update that will be called when the CountReached event is raised
    public void Update(object sender, EventArgs e, String name)
    {
        Console.WriteLine(name + ": Count reached! " + sender.GetType() + ", " + name);
    }

    public void Update2(object sender, EventArgs e)
    {
        Console.WriteLine(name + ": Count reached!222222222");
    }
}
