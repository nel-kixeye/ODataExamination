using ODataLibrary.Services;
using Trippin;

namespace ODataLibrary.Commands;
public class ListPeopleCommand : Commands
{
    public ListPeopleCommand(PeopleService peopleService) : base(peopleService){}

    public override string CommandName => "ListPeople";

    public override async Task<IEnumerable<Person>> Execute()
    {
        return await _peopleService.PeopleList();
    }
}
