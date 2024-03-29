using ODataLibrary.Commands.PeopleCommands;
using ODataLibrary.Services;
using Trippin;

namespace ODataLibrary.Commands.PersonCommand;
public class ShowPersonDetails : PersonCommand
{
    private readonly string _username;
    public ShowPersonDetails(PeopleService peopleService, string username) : base(peopleService)
    {
        _username = username;
    }

    public override string CommandName => "ShowPersonDetails";

    public override async Task<Person?> Execute()
    {
       return await _peopleService.PersonDetails(_username);
    }
}
