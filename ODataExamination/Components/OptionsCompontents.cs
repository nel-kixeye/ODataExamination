using Microsoft.OData.UriParser;

namespace ODataExamination.Components;
internal class OptionsCompontents : IComponents
{
    public string Identifier { get; set; } = "Options";

    public async Task Render(string? args = null)
    {
        bool exitFlag = true;
        while (exitFlag) 
        {
            var invalid = new InvalidEntryComponents();
            List<IComponents> components = [new ListAllComponents(), new SearchPeopleComponents(), new ShowPersonDetailsComponents()];

            Console.Clear();
            Console.WriteLine("Please select from the following options:");
            Console.WriteLine("1. List all people.");
            Console.WriteLine("2. Search/Filter people");
            Console.WriteLine("3. Show Person's detail");
            Console.WriteLine("4. Exit");
            Console.Write("Enter command number : ");
            var option = Console.ReadLine();
            int optionResult = 0;
            if (option == null
                || (int.TryParse(option, out optionResult) && (optionResult < 1 || optionResult > 4)))
            {
                invalid.Render();
            }

            foreach (var component in components) 
            {
                if (component.Identifier == optionResult.ToString()) 
                {
                    await component.Render();
                    break;
                }
            }

            if (optionResult == 4) 
            {
                exitFlag = false;
            }
        }

        


    }
}
