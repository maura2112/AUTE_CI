public class CommandInvoker<T>
{
    private readonly List<ICommand<T>> commands = new();

    public void AddCommand(ICommand<T> command) => commands.Add(command);

    public List<T> ExecuteAll()
    {
        var results = new List<T>();
        foreach (var command in commands)
        {
            results.Add(command.Execute());
        }
        return results;
    }
}
