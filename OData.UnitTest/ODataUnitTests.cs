using OData.DataLibrary.Data;
using ODataLibrary.Commands.PeopleCommands;
using ODataLibrary.Commands.PersonCommand;
using ODataLibrary.Services;
using System.Runtime.CompilerServices;

namespace OData.UnitTest;

public class ODataUnitTests
{
    private readonly PeopleService _peopleService;
    private readonly PeopleCommandManager _peopleCommandManager;
    private readonly PersonCommandManager _personCommandManager;   
    public ODataUnitTests()
    {
        //set up dependencies
        var apiContext = new APIContext();
        _peopleService = new PeopleService(apiContext);
        _peopleCommandManager = new PeopleCommandManager();
        _personCommandManager = new PersonCommandManager();
    }

    [Fact]
    public async Task ListPeopleUnitTest()
    {
        var listPeopleCommand = new ListPeopleCommand(_peopleService);
        _peopleCommandManager.AddCommand(listPeopleCommand);
        await _peopleCommandManager.ExecuteCommandAsync("ListPeople");
        var result = _peopleCommandManager.CurrentResult;

        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("russellwhyte")]
    public async Task SearchOrFilterUnitTest(string keyword)
    {
        var filterPeopleCommand = new FilterPeopleCommand(_peopleService, keyword);
        _peopleCommandManager.AddCommand(filterPeopleCommand);
        await _peopleCommandManager.ExecuteCommandAsync("FilterPeople");
        var result = _peopleCommandManager.CurrentResult;

        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("javieralfred")]
    public async Task ShowDetailsUnitTest(string username)
    {
        var showPersonDetails = new ShowPersonDetails(_peopleService, username);
        _personCommandManager.AddCommand(showPersonDetails);
        await _personCommandManager.ExecuteCommandAsync("ShowPersonDetails");
        var result = _personCommandManager.CurrentResult;

        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("test")]
    public async Task ShowDetailsNullUnitTest(string username)
    {
        var showPersonDetails = new ShowPersonDetails(_peopleService, username);
        _personCommandManager.AddCommand(showPersonDetails);
        await _personCommandManager.ExecuteCommandAsync("ShowPersonDetails");
        var result = _personCommandManager.CurrentResult;

        Assert.Null(result);
    }
}