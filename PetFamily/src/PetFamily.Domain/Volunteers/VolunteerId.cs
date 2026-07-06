using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Volunteers;

public record VolunteerId : BaseId
{
    private VolunteerId(Guid value) : base(value) { }

    public static VolunteerId NewId() => new(Guid.NewGuid());
    public static VolunteerId Empty() => new(Guid.Empty);
    public static VolunteerId Create(Guid id) => new(id);
}