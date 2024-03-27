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
        IEnumerable<Person> people = await _context.People.ExecuteAsync();
        return people;
    }
}
