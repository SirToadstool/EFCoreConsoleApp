namespace Fiddle.Interfaces;

public interface IConverter
{
    void SetStrategy(IStrategy strategy);
    string ExecuteStrategy(string input);
}