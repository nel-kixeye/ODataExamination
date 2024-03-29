using Trippin;

namespace OData.DataLibrary.Data;
public class APIContext
{
    private const string serviceRoot = "https://services.odata.org/TripPinRESTierService";
    private readonly Container _context;
    public APIContext()
    {
        _context = new Container(new Uri(serviceRoot));
    }
    public async Task<IEnumerable<Person>> People() 
    {
        return await People(null);
    }

    public async Task<IEnumerable<Person>> People(string? filter)
    {
        if (filter is not { }) 
        {
            return await _context.People.ExecuteAsync();
        }
        return (await _context.People.ExecuteAsync()).Where(p => 
        p.UserName == filter 
        || p.FirstName == filter
        || p.LastName == filter
        || p.Gender.ToString() == filter
        || p.Age.ToString() == filter
        || p.FavoriteFeature.ToString() == filter
        || p.Emails.Contains(filter));
    }
}
