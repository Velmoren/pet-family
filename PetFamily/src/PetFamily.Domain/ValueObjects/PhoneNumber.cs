using System.Text.RegularExpressions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.ValueObjects;

public record PhoneNumber
{
    public string Value { get; }

    private PhoneNumber(string value)
    {
        Value = value;
    }

    public static Result<PhoneNumber> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Errors.General.ValueIsRequired("Value");
        }

        var cleaned = Regex.Replace(value, @"[^\d+]", "");

        if (!Regex.IsMatch(cleaned, @"^\+?\d{10,15}$"))
        {
            return Errors.General.ValueIdInvalid("Value");
        }

        return new PhoneNumber(cleaned);
    }

    public override string ToString() => Value;
}