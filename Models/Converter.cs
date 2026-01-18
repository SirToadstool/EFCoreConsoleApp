using Fiddle.Interfaces;

namespace Fiddle.Models;

public class Converter(IStrategy strategy) : IConverter
{
    private IStrategy _strategy = strategy;

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public string ExecuteStrategy(string input)
    {
        return _strategy.Convert(input) ?? string.Empty;
    }
}