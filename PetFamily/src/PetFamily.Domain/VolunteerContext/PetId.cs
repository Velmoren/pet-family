using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.VolunteerContext;

public record PetId : BaseId
{
    private PetId(Guid value) : base(value) { }

    public static PetId NewId() => new(Guid.NewGuid());
    public static PetId Empty() => new(Guid.Empty);
    public static PetId Create(Guid id) => new(id);
}