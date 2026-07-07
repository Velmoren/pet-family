using CSharpFunctionalExtensions;

using Entity = PetFamily.Domain.Shared.Entity<PetFamily.Domain.SpeciesContext.BreedId>;

namespace PetFamily.Domain.SpeciesContext;

public class Breed : Entity
{
    private Breed(BreedId id) : base(id) { }

    private Breed(BreedId id, string name) : base(id)
    {
        Name = name;
    }
    
    public string Name { get; private set; } = string.Empty;
    
    internal static Result<Breed> Create(BreedId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Breed>("Name cannot be empty");
        }

        var breed = new Breed(id, name);

        return Result.Success(breed);
    }
}