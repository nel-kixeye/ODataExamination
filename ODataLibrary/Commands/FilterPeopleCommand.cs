using ODataLibrary.Services;
using Trippin;

namespace ODataLibrary.Commands;
public class FilterPeopleCommand : Commands
{
    public FilterPeopleCommand(PeopleService peopleService) : base(peopleService)
    {
    }

    public override string CommandName => "FilterPeople";

    public override async Task<IEnumerable<Person>> Execute()
    {
        throw new NotImplementedException();
    }
}
