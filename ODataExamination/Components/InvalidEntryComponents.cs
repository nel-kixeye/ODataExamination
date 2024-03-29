namespace ODataExamination.Components;
internal class InvalidEntryComponents : IComponents
{
    public string Identifier { get; set; } = "Invalid";

    public async Task Render(string? args = null)
    {
        Console.Clear();
        Console.WriteLine("You have entered an invalid input! Press enter to try again");
        Console.ReadLine();
        return;
    }
}
