using Fiddle.Interfaces;

namespace Fiddle.Models;

public class Bird : IAnimal
{
    public string Speak() { return "Tweet!"; }
}