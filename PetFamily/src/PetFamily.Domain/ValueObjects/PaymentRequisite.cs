namespace PetFamily.Domain.ValueObjects;

public record PaymentRequisite
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

    private PaymentRequisite() { }

    public PaymentRequisite(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Название реквизита не может быть пустым.", nameof(name));

        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Описание перевода не может быть пустым.", nameof(description));

        Name = name;
        Description = description;
    }
}