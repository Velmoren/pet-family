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
            return Errors.General.ValueIsRequired("Name");
        }

        if (string.IsNullOrWhiteSpace(description))
        {
            return Errors.General.ValueIsRequired("Description");
        }

        return new PaymentRequisite(name, description);
    }
}