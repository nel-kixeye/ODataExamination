using ODataLibrary.DTO;

namespace ODataLibrary.Commands.PeopleCommands;
public class PeopleCommandManager
{
    private IEnumerable<PersonNameDTO>? _people;

    private List<PeopleCommand> CommandCollection = new List<PeopleCommand>();
    public IEnumerable<PersonNameDTO>? CurrentResult { get { return _people; } }
    public void AddCommand(PeopleCommand command)
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
