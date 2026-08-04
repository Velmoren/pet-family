using System.Text.RegularExpressions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.ValueObjects;

public partial record Email
{
    // Регулярное выражение генерируется при компиляции с таймаутом в 1 секунду
    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, 1000)]
    private static partial Regex EmailRegex();
    
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Result<Email> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "Email не может быть пустым.";
        }
        
        var trimmedEmail = value.Trim().ToLowerInvariant();

        if (!EmailRegex().IsMatch(trimmedEmail))
        {
            return "Неверный формат Email.";
        }

        return new Email(trimmedEmail);
    }

    public override string ToString() => Value;
}