using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.SpeciesContext;

public record BreedId : BaseId
{
    private BreedId(Guid value) : base(value) { }

    public static BreedId NewId() => new(Guid.NewGuid());
    public static BreedId Empty() => new(Guid.Empty);
    public static BreedId Create(Guid id) => new(id);
}