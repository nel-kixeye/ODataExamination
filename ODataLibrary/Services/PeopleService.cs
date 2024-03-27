using OData.DataLibrary.Data;
using ODataLibrary.DTO;
using Trippin;

namespace ODataLibrary.Services;
public class PeopleService
{
    private readonly APIContext _apiContext;
    public PeopleService(APIContext apiContext)
    {
        _apiContext = apiContext;
    }
    public async Task<IEnumerable<PersonNameDTO>?> PeopleList()
    {
        var peopleResult = (await _apiContext.People());
        return PreparePersonDTOResult(peopleResult);
    }

    public async Task<IEnumerable<PersonNameDTO>?> PeopleFilteredList(string filter) 
    {
        var peopleResult = await _apiContext.People(filter);
        return PreparePersonDTOResult(peopleResult);
    }

    public async Task<Person?> PersonDetails(string username) 
    {
        var personResult = (await _apiContext.People()).Where(per => per.UserName == username);
        return personResult.FirstOrDefault();
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
