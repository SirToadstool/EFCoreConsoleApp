using Fiddle.Interfaces;

namespace Fiddle.Models;

public class Cat : IAnimal
{
    public string Speak() { return "Meow!"; }
}