using Fiddle.Interfaces;

namespace Fiddle.Models;

public class Dog : IAnimal
{
    public string Speak() { return "Woof!"; }
}