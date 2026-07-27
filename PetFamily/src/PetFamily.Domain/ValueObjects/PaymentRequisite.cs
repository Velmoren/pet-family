using PetFamily.Domain.Shared;

namespace PetFamily.Domain.ValueObjects;

public record PaymentRequisite
{
    public string Name { get; } = string.Empty;
    public string Description { get; } = string.Empty;

    private PaymentRequisite(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public static Result<PaymentRequisite> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return "Название реквизита не может быть пустым.";
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            return "Описание перевода не может быть пустым.";
        }

        return new PaymentRequisite(name, description);
    }
}