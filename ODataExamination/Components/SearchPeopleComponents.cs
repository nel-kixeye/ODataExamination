using ODataLibrary.Services;
using OData.DataLibrary.Data;
using ODataLibrary.Commands.PeopleCommands;
using Trippin;

namespace ODataExamination.Components;
internal class SearchPeopleComponents : IComponents
{
    public string Identifier { get; set; } = "2";

    public async Task Render(string? args = null)
    {
        //set up dependencies
        var apiContext = new APIContext();
        var peopleService = new PeopleService(apiContext);
        var peopleCommandManager = new PeopleCommandManager();

        Console.Clear();
        Console.WriteLine("Search/Filter : ");
        Console.WriteLine("Kindly note the the following are what is considered for filtering : ");
        Console.WriteLine("Username");
        Console.WriteLine("Firstname");
        Console.WriteLine("Lastname");
        Console.WriteLine("Age");
        Console.WriteLine("Email");
        Console.WriteLine("Gender");
        Console.WriteLine("Favorite Feature");
        Console.WriteLine("Search keyword : ");
        var keyword = Console.ReadLine();

        if (keyword is not { }) 
        {
            Console.WriteLine($"{keyword} is not found!");
            return;
        }
        //execute filtering people command
        var filterPeopleCommand = new FilterPeopleCommand(peopleService, keyword);
        peopleCommandManager.AddCommand(filterPeopleCommand);
        await peopleCommandManager.ExecuteCommandAsync("FilterPeople");
        var filteredPeople = peopleCommandManager.CurrentResult;
        Console.WriteLine($"Username : Lastname, Firstname ");
        if (filteredPeople is { })
        {
            foreach (var fPerson in filteredPeople)
            {
                Console.WriteLine($"{fPerson.UserName} : {fPerson.LastName}, {fPerson.FirstName} ");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press enter to get back to options");
        Console.ReadLine();
        return;
    }
}
