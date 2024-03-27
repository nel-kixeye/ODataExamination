using CommonLibrary.Models;

namespace CommonLibrary.Extensions;
public static class PersonExtensions
{
    public static string TypeInText(this Person person) => person.GetType().Name.ToString();
}
