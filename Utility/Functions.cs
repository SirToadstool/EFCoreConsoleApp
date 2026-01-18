using Fiddle.Enums;
using Fiddle.Factories;
using Fiddle.Interfaces;
using Fiddle.Models;

namespace Fiddle.Utility;

public static class Functions
{
    public static void CreateObserver()
    {
        WeatherStation weatherStation = new();

        PhoneDisplay phone1 = new("Phone 1");
        PhoneDisplay phone2 = new("Phone 2");

        weatherStation.Attach(phone1);
        weatherStation.Attach(phone2);

        weatherStation.Temperature = 25.5f;
        weatherStation.Temperature = 35.6f;

        weatherStation.Detach(phone1);
        weatherStation.Temperature = 27.0f;
    }

    public static void CreateAnimalFactory()
    {
        AnimalFactory animalFactory = new();
        
        IAnimal dog = animalFactory.Get(AnimalType.Dog);
        IAnimal cat = animalFactory.Get(AnimalType.Cat);
        IAnimal bird = animalFactory.Get(AnimalType.Bird);

        Console.WriteLine($"Dog says {dog.Speak()}");
        Console.WriteLine($"Cat says {cat.Speak()}");
        Console.WriteLine($"Bird says {bird.Speak()}");
    }

    public static void CreateStrategy()
    {
        Converter converter = new(new JsonConverter());
        string input = "this is some cool data";
        
        Console.WriteLine(converter.ExecuteStrategy(input));
        converter.SetStrategy(new XmlConverter());
        Console.WriteLine(converter.ExecuteStrategy(input));
        converter.SetStrategy(new CsvConverter());
        Console.WriteLine(converter.ExecuteStrategy(input));
    }
}