using ODataLibrary.DTO;
using ODataLibrary.Services;

namespace ODataLibrary.Commands;
public abstract class Commands
{
    protected readonly PeopleService _peopleService;
    public Commands(PeopleService peopleService)
    {
        _peopleService = peopleService;
    }
    public abstract string CommandName { get; }
    public abstract Task<IEnumerable<PersonNameDTO>?> Execute();
}
