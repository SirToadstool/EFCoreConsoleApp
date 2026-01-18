using Fiddle.Interfaces;

namespace Fiddle.Models;

public class JsonConverter : IStrategy
{
    public string Convert(string input)
    {
        return $"{{ \"data\": \"{input}\" }}";
    }
}
