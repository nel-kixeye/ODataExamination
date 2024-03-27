using ODataLibrary.Services;
using Trippin;

namespace ODataLibrary.Commands.PersonCommand;
public abstract class PersonCommand
{
    protected readonly PeopleService _peopleService;
    public PersonCommand(PeopleService peopleService)
    {
        _peopleService = peopleService;
    }
    public abstract string CommandName { get; }
    public abstract Task<Person?> Execute();
}
