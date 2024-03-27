using Trippin;

namespace ODataLibrary.Commands.PersonCommand;
public class PersonCommandManager
{
    private Person? _person;

    private List<PersonCommand> CommandCollection = new List<PersonCommand>();
    public Person? CurrentResult { get { return _person; } }
    public void AddCommand(PersonCommand command)
    {
        CommandCollection.Add(command);
    }

    public async Task ExecuteCommandAsync(string commandName)
    {
        if (CommandCollection.Any(cc => cc.CommandName == commandName))
        {
            var comms = CommandCollection.First(x => x.CommandName == commandName);
            _person = await comms.Execute();
        }
    }
}
