using System.Text.RegularExpressions;

namespace PetFamily.Domain.ValueObjects;

public record Email
{
    public string Value { get; init; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email не может быть пустым.");

        var trimmedEmail = value.Trim().ToLowerInvariant();

        var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(trimmedEmail, emailRegex))
            throw new ArgumentException("Неверный формат Email.");

        Value = trimmedEmail;
    }

    public override string ToString() => Value;
}