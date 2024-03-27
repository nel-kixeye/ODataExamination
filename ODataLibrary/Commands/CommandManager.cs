using ODataLibrary.DTO;

namespace ODataLibrary.Commands;
public class CommandManager
{
    private IEnumerable<PersonNameDTO>? _people;   

    private List<Commands> CommandCollection = new  List<Commands>();
    public IEnumerable<PersonNameDTO>? CurrentResult { get { return _people; } }
    public void AddCommand(Commands command) 
    {
        CommandCollection.Add(command);
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
