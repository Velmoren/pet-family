using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.SpeciesContext;

public record SpeciesId : BaseId
{
    private SpeciesId(Guid value) : base(value) { }

    public static SpeciesId NewId() => new(Guid.NewGuid());
    public static SpeciesId Empty() => new(Guid.Empty);
    public static SpeciesId Create(Guid id) => new(id);
}