using Fiddle.Interfaces;

namespace Fiddle.Models;

public class CsvConverter : IStrategy
{
    public string Convert(string input)
    {
        return $"data,{input}";
    }
}