using PetFamily.Domain.Shared;

namespace PetFamily.Domain.ValueObjects;

public record Address
{
    public string Country { get; }
    public string City { get; }
    public string Street { get; }
    public string House { get; }
    public string? Apartment { get; }
    public string? PostalCode { get; }

    private Address(string country, string city, string street, string house, string? apartment, string? postalCode)
    {
        Country = country;
        City = city;
        Street = street;
        House = house;
        Apartment = apartment;
        PostalCode = postalCode;
    }

    public static Result<Address> Create(string country, string city, string street, string house, string? apartment,
        string? postalCode)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(country)) errors.Add("Страна обязательна.");
        if (string.IsNullOrWhiteSpace(city)) errors.Add("Город обязателен.");
        if (string.IsNullOrWhiteSpace(street)) errors.Add("Улица обязательна.");
        if (string.IsNullOrWhiteSpace(house)) errors.Add("Номер дома обязателен.");

        if (errors.Any())
        {
            return string.Join(" ", errors);
        }

        return new Address(
            country.Trim(),
            city.Trim(),
            street.Trim(),
            house.Trim(),
            apartment?.Trim(),
            postalCode?.Trim()
        );
    }
}