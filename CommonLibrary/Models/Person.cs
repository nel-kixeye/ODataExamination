using CommonLibrary.Enums;

namespace CommonLibrary.Models;
public record Person(
    string UserName,
    string FirstName,
    string LastName,
    string? MiddleName,
    Geneder Gender,
    int? Age,
    IEnumerable<string> Emails,
    string FavoriteFeature,
    IEnumerable<string> Features,
    IEnumerable<string> AddressInfo,
    string? HomeAddress);
