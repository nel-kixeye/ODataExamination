using ODataLibrary.Commands;
using ODataLibrary.Services;
using OData.DataLibrary.Data;

//set up dependencies
var apiContext = new APIContext();
var peopleService = new PeopleService(apiContext);
var commandManager = new CommandManager();

Console.WriteLine();
Console.WriteLine("All People");
Console.WriteLine();

//execute listing people command
var listPeopleCommand = new ListPeopleCommand(peopleService);
commandManager.AddCommand(listPeopleCommand);
await commandManager.ExecuteCommandAsync("ListPeople");
var people = commandManager.CurrentResult;
if (people is { }) 
{
    foreach (var person in people)
    {
        Console.WriteLine(person.UserName);
    }
}

Console.WriteLine();
Console.WriteLine("Filtered People");
Console.WriteLine();

//execute filtering people command
var filterPeopleCommand = new FilterPeopleCommand(peopleService, "russellwhyte");
commandManager.AddCommand(filterPeopleCommand);
await commandManager.ExecuteCommandAsync("FilterPeople");
var filteredPeople = commandManager.CurrentResult;
if (filteredPeople is { })
{
    foreach (var person in filteredPeople)
    {
        Console.WriteLine(person.UserName);
    }
}
