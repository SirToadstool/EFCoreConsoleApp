using Fiddle.Enums;
using Fiddle.Interfaces;
using Fiddle.Models;

namespace Fiddle.Factories;

public interface IAnimalFactory
{
    IAnimal Get(AnimalType animalType);
}

public class AnimalFactory : IAnimalFactory
{
    public IAnimal Get(AnimalType animalType)
    {
        return animalType switch
        {
            AnimalType.Dog => new Dog(),
            AnimalType.Cat => new Cat(),
            AnimalType.Bird => new Bird(),
            _ => throw new Exception("Unknown animal type")
        };
    }
}