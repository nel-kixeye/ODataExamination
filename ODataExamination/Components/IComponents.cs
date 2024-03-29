namespace ODataExamination.Components;
public interface IComponents
{
    public string Identifier { get; set; }
    public Task Render(string? args = null); 
}
