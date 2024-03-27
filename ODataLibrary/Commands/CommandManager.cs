using Trippin;

namespace ODataLibrary.Commands;
public class CommandManager
{
    private IEnumerable<Person>? _people;   

    private List<Commands> CommandCollection = new  List<Commands>();
    public IEnumerable<Person>? CurrentResult { get { return _people; } }
    public void AddCommand(Commands command) 
    {
        if (!CommandCollection.Any(cc => cc.CommandName == command.CommandName)) 
        {
            CommandCollection.Add(command);
        }
    }

    public void RemoveCommand(Commands command) 
    {
        if (CommandCollection.Any(cc => cc.CommandName == command.CommandName))
        {
            CommandCollection.Remove(command);
        }
    }

    public async Task ExecuteCommandAsync(string commandName) 
    {
        if (CommandCollection.Any(cc => cc.CommandName == commandName))
        {
            var comms = CommandCollection.First(x => x.CommandName == commandName);
            _people = await comms.Execute();
        }
    }
}
