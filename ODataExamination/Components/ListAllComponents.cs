using ODataLibrary.Services;
using OData.DataLibrary.Data;
using ODataLibrary.Commands.PeopleCommands;
using Trippin;

namespace ODataExamination.Components;
internal class ListAllComponents : IComponents
{
    public string Identifier { get; set; } = "1";    

    public async Task Render(string? args = null)
    {
        //set up dependencies
        var apiContext = new APIContext();
        var peopleService = new PeopleService(apiContext);
        var peopleCommandManager = new PeopleCommandManager();

        Console.Clear();
        Console.WriteLine("List All People : ");

        //execute listing people command
        var listPeopleCommand = new ListPeopleCommand(peopleService);
        peopleCommandManager.AddCommand(listPeopleCommand);
        await peopleCommandManager.ExecuteCommandAsync("ListPeople");
        var people = peopleCommandManager.CurrentResult;
        Console.WriteLine($"Username : Lastname, Firstname ");
        if (people is { })
        {
            foreach (var pFerson in people)
            {
                Console.WriteLine($"{pFerson.UserName} : {pFerson.LastName}, {pFerson.FirstName} ");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press enter to get back to options");
        Console.ReadLine();
        return;
    }
}
