using ODataLibrary.Services;
using Trippin;

namespace ODataLibrary.Commands;
public class ShowPersonDetails : Commands
{
    public ShowPersonDetails(PeopleService peopleService) : base(peopleService)
    {
    }

    public override string CommandName => "ShowPersonDetails";

    public override async Task<IEnumerable<Person>> Execute()
    {
        throw new NotImplementedException();
    }
}
