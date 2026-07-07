using System.Text.RegularExpressions;

namespace PetFamily.Domain.ValueObjects;

public record PhoneNumber
{
    public string Value { get; init; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Номер телефона не может быть пустым.");

        var cleaned = Regex.Replace(value, @"[^\d+]", "");

        if (!Regex.IsMatch(cleaned, @"^\+?\d{10,15}$"))
            throw new ArgumentException("Неверный формат номера телефона.");

        Value = cleaned;
    }

    public override string ToString() => Value;
}