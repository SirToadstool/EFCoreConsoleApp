using Fiddle.Interfaces;

namespace Fiddle.Models;

public class XmlConverter : IStrategy
{
    public string Convert(string input)
    {
        return $"<data>{input}</input>";
    }
}