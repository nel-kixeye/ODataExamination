using CommonLibrary.Enums;

namespace CommonLibrary.Models.Sub;
public record Manager(
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
    string? HomeAddress)
    : Person(
        UserName,
        FirstName,
        LastName,
        MiddleName,
        Gender,
        Age,
        Emails,
        FavoriteFeature,
        Features,
        AddressInfo,
        HomeAddress);
