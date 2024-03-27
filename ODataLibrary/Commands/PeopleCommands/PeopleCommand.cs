using ODataLibrary.DTO;
using ODataLibrary.Services;

namespace ODataLibrary.Commands.PeopleCommands;
public abstract class PeopleCommand
{
    protected readonly PeopleService _peopleService;
    public PeopleCommand(PeopleService peopleService)
    {
        _peopleService = peopleService;
    }
    public abstract string CommandName { get; }
    public abstract Task<IEnumerable<PersonNameDTO>?> Execute();
}
