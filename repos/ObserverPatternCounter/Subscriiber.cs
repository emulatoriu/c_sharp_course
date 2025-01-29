using ObserverPatternCounter;

public class Counter : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private List<String> names = new List<String>() { "Arsen", "Tina", "Thomas", "Dominik", "Pascal", "Alex", "Nino", "Mario"};

    public void Count(int maxCount)
    {
        for (int count = 1; count <= maxCount; count++)
        {
            if (count == maxCount)
            {
                NotifyObservers(maxCount);
            }
        }
    }

    public void StartsWithT()
    {
        int chosenIndex = new Random().Next(0, names.Count());
        if (names[chosenIndex].StartsWith("T"))
        {
            NotifyObserversNameChosen(names[chosenIndex]);
        }
    }

    

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(int maxCount)
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(maxCount);
            observer.Update2(maxCount);
        }
    }

    public void NotifyObserversNameChosen(String name)
    {
        foreach (IObserver observer in observers)
        {
            observer.NotifyNameFound(name);
        }
    }
}