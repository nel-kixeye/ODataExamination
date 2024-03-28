using Simple.OData.Client;
using Trippin;

namespace OData.DataLibrary.Data;
public class APIContext
{
    private const string serviceRoot = "https://services.odata.org/TripPinRESTierService";
    private readonly Container _context;
    private readonly ODataClient _client;
    public APIContext()
    {
        _context = new Container(new Uri(serviceRoot));
        _client = new ODataClient(new Uri(serviceRoot));
    }
    public async Task<IEnumerable<Person>> People() 
    {
        return await People(null);
    }

    public async Task<IEnumerable<Person>> People(string? filter)
    {
        var peopleQuery = await _context.People.ExecuteAsync();
        if (filter is not { }) 
        {
            return peopleQuery;
        }

        return peopleQuery.Where(p => p.UserName == filter || p.FirstName == filter || p.LastName == filter).Take(100);
    }

    public async Task<Person?> NewPeople(Person person)
    {
        try 
        {
            //var people = await _client.FindEntriesAsync();
        }
        catch
        {
            return null;
        }
        return null;
    }
}
