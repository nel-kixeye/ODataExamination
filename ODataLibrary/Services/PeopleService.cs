using OData.DataLibrary.Data;
using ODataLibrary.DTO;
using Trippin;

namespace ODataLibrary.Services;
public class PeopleService
{
    private readonly APIContext _peopleService;
    public PeopleService(APIContext apiContext)
    {
        _peopleService = apiContext;
    }
    public async Task<IEnumerable<PersonNameDTO>?> PeopleList()
    {
        var peopleResult = (await _peopleService.People());
        return PreparePersonDTOResult(peopleResult);
    }

    public async Task<IEnumerable<PersonNameDTO>?> PeopleFilteredList(string filter) 
    {
        var peopleResult = await _peopleService.People(filter);
        return PreparePersonDTOResult(peopleResult);
    }

    private IEnumerable<PersonNameDTO>? PreparePersonDTOResult(IEnumerable<Person> people) 
    {
        var processedPeople = people.Select(p => new { p.UserName, p.FirstName, p.LastName });
        var dto = new List<PersonNameDTO>();
        if (processedPeople is not { })
        {
            return null;
        }
        foreach (var person in processedPeople)
        {
            dto.Add(new PersonNameDTO()
            {
                UserName = person.UserName,
                FirstName = person.FirstName,
                LastName = person.LastName
            });
        }
        return dto;
    }

}
