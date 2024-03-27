using OData.DataLibrary.Data;
using Trippin;

namespace ODataLibrary.Services;
public class PeopleService
{
    private readonly APIContext _peopleService;
    public PeopleService(APIContext apiContext)
    {
        _peopleService = apiContext;
    }
    public async Task<IEnumerable<Person>> PeopleList() 
    {
        return await _peopleService.People();
    }

}
