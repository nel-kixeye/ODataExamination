using ODataLibrary.DTO;
using ODataLibrary.Services;

namespace ODataLibrary.Commands.PeopleCommands;
public class FilterPeopleCommand : PeopleCommand
{
    private readonly string filter;
    public FilterPeopleCommand(PeopleService peopleService, string filter) : base(peopleService)
    {
        this.filter = filter;
    }

    public override string CommandName => "FilterPeople";

    public override async Task<IEnumerable<PersonNameDTO>?> Execute()
    {
        return await _peopleService.PeopleFilteredList(filter);
    }
}
