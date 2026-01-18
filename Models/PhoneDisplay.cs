using Fiddle.Interfaces;

namespace Fiddle.Models;

public class PhoneDisplay(string name) : IObserver
{
    private readonly string _name = name;

    public void Update(ISubject subject)
    {
        if (subject is WeatherStation station)
        {
            Console.WriteLine($"{_name} received update. Temperature is now {station.Temperature} degrees Celsius");
        }
    }
}