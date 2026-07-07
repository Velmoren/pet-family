namespace PetFamily.Domain.ValueObjects;

public record Address
{
    public string Country { get; init; }
    public string City { get; init; }
    public string Street { get; init; }
    public string House { get; init; }
    public string Apartment { get; init; }
    public string PostalCode { get; init; }

    public Address(string country, string city, string street, string house, string apartment = null, string postalCode = null)
    {
        if (string.IsNullOrWhiteSpace(country)) throw new ArgumentException("Страна обязательна.");
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentException("Город обязателен.");
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentException("Улица обязательна.");
        if (string.IsNullOrWhiteSpace(house)) throw new ArgumentException("Номер дома обязателен.");

        Country = country.Trim();
        City = city.Trim();
        Street = street.Trim();
        House = house.Trim();
        Apartment = apartment?.Trim();
        PostalCode = postalCode?.Trim();
    }

    public override string ToString()
    {
        var parts = new List<string> { PostalCode, Country, City, Street, House, Apartment };
        return string.Join(", ", parts.Where(p => !string.IsNullOrWhiteSpace(p)));
    }
}