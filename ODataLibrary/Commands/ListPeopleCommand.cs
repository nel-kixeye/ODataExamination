﻿using ODataLibrary.DTO;
using ODataLibrary.Services;

namespace ODataLibrary.Commands;
public class ListPeopleCommand : Commands
{
    public ListPeopleCommand(PeopleService peopleService) : base(peopleService){}

    public override string CommandName => "ListPeople";

    public override async Task<IEnumerable<PersonNameDTO>?> Execute()
    {
        return await _peopleService.PeopleList();
    }
}
