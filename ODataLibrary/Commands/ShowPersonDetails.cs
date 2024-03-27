using ODataLibrary.DTO;
using ODataLibrary.Services;

namespace ODataLibrary.Commands;
public class ShowPersonDetails : Commands
{
    public ShowPersonDetails(PeopleService peopleService) : base(peopleService)
    {
    }

    public override string CommandName => "ShowPersonDetails";

    public override async Task<IEnumerable<PersonNameDTO>?> Execute()
    {
        throw new NotImplementedException();
    }
}
