using ODataLibrary.Services;
using OData.DataLibrary.Data;
using ODataLibrary.Commands.PersonCommand;

namespace ODataExamination.Components;
internal class ShowPersonDetailsComponents : IComponents
{
    public string Identifier { get; set; } = "3";   

    public async Task Render(string? args = null)
    {
        //set up dependencies
        var apiContext = new APIContext();
        var peopleService = new PeopleService(apiContext);
        var personCommandManager = new PersonCommandManager();

        Console.Clear();
        Console.WriteLine("Show Details : ");
        Console.Write("Username : ");
        var username = Console.ReadLine();

        if (username is not { })
        {
            Console.WriteLine($"{username} is not found!");
            return;
        }
        //execute filtering people command
        var showPersonDetails = new ShowPersonDetails(peopleService, username);
        personCommandManager.AddCommand(showPersonDetails);
        await personCommandManager.ExecuteCommandAsync("ShowPersonDetails");
        var person = personCommandManager.CurrentResult;
        if (person is { })
        {
            Console.WriteLine($"Name : {person.LastName}, {person.FirstName} {person.MiddleName}");
            if (person.Age is { }) 
            {
                Console.WriteLine($"Age : {person.Age}");
            }
            if (person.FavoriteFeature is { }) 
            {
                Console.WriteLine($"Favorite Feature : {person.FavoriteFeature}");
            }
            if(person.Features is { } && person.Features.Count > 0) 
            {
                Console.WriteLine($"Features : ");
                foreach (var feature in person.Features)
                {
                    Console.WriteLine($"=> {feature}");
                }
            }
            if (person.Emails is { } && person.Emails.Count > 0) 
            {
                Console.WriteLine($"Emails : ");
                foreach (var email in person.Emails)
                {
                    Console.WriteLine($"=> {email}");
                }
            }
            if (person.HomeAddress is { }) 
            {
                Console.WriteLine($"Home Address : {person.HomeAddress.Address} " +
                    $"{person.HomeAddress.City.Name} " +
                    $"{person.HomeAddress.City.Region} " +
                    $"{person.HomeAddress.City.CountryRegion}");
            }
            if (person.AddressInfo is { } && person.AddressInfo.Count > 0) 
            {
                Console.WriteLine($"Address Info : ");
                foreach (var addresses in person.AddressInfo)
                {
                    Console.WriteLine($"=> {addresses.Address} " +
                    $"{addresses.City.Name} " +
                    $"{addresses.City.Region} " +
                    $"{addresses.City.CountryRegion}");
                }
            }
            
        }

        Console.WriteLine();
        Console.WriteLine("Press enter to get back to options");
        Console.ReadLine();
        return;
    }
}
