using ODataLibrary.Services;
using Trippin;

namespace ODataLibrary.Commands.PersonCommand;
public class CreatePerson : PersonCommand
{
    private readonly Person _person;
    public CreatePerson(PeopleService peopleService, Person newPerson) : base(peopleService)
    {
        _person = newPerson;
    }

    public override string CommandName => "CreatePerson";

    public override async Task<Person?> Execute()
    {
        return await _peopleService.CreatePerson(_person);
    }
}
