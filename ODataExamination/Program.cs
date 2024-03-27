using ODataLibrary.Commands;
using ODataLibrary.Services;
using OData.DataLibrary.Data;

//set up dependencies
var apiContext = new APIContext();
var peopleService = new PeopleService(apiContext);
var listPeopleCommand = new ListPeopleCommand(peopleService);
var commandManager = new CommandManager();

//prepare command manager
commandManager.AddCommand(listPeopleCommand);

//execute listing people command
await commandManager.ExecuteCommandAsync("ListPeople");
var people = commandManager.CurrentResult;
if (people is { }) 
{
    foreach (var person in people)
    {
        Console.WriteLine(person.UserName);
    }
}
