using Fiddle.Interfaces;

namespace Fiddle.Models;

public class WeatherStation : ISubject
{
    private readonly List<IObserver> _observers = [];
    private float _temperature;

    public float Temperature
    {
        get { return _temperature; }
        set
        {
            _temperature = value;
            Notify();
        }
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in _observers)
        {
            observer.Update(this);
        }
    }
}
