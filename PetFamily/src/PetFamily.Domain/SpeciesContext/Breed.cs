using PetFamily.Domain.Shared;

namespace PetFamily.Domain.SpeciesContext;

public class Breed : Entity<BreedId>
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
            return "Name cannot be empty";
        }

        return new Breed(id, name);
    }
}