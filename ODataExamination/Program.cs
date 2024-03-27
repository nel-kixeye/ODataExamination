using ODataLibrary.Services;
using OData.DataLibrary.Data;
using ODataLibrary.Commands.PeopleCommands;
using ODataLibrary.Commands.PersonCommand;

//set up dependencies
var apiContext = new APIContext();
var peopleService = new PeopleService(apiContext);
var peopleCommandManager = new PeopleCommandManager();
var personCommandManager = new PersonCommandManager();

Console.WriteLine();
Console.WriteLine("All People");
Console.WriteLine();

//execute listing people command
var listPeopleCommand = new ListPeopleCommand(peopleService);
peopleCommandManager.AddCommand(listPeopleCommand);
await peopleCommandManager.ExecuteCommandAsync("ListPeople");
var people = peopleCommandManager.CurrentResult;
if (people is { }) 
{
    foreach (var pFerson in people)
    {
        Console.WriteLine(pFerson.UserName);
    }
}

Console.WriteLine();
Console.WriteLine("Filtered People");
Console.WriteLine();

//execute filtering people command
var filterPeopleCommand = new FilterPeopleCommand(peopleService, "russellwhyte");
peopleCommandManager.AddCommand(filterPeopleCommand);
await peopleCommandManager.ExecuteCommandAsync("FilterPeople");
var filteredPeople = peopleCommandManager.CurrentResult;
if (filteredPeople is { })
{
    foreach (var fPerson in filteredPeople)
    {
        Console.WriteLine(fPerson.UserName);
    }
}

Console.WriteLine();
Console.WriteLine("Show People");
Console.WriteLine();

//execute filtering people command
var showPersonDetails = new ShowPersonDetails(peopleService, "russellwhyte");
personCommandManager.AddCommand(showPersonDetails);
await personCommandManager.ExecuteCommandAsync("ShowPersonDetails");
var person = personCommandManager.CurrentResult;
if (person is { })
{
    Console.WriteLine(person.LastName + ", " + person.FirstName);
}
