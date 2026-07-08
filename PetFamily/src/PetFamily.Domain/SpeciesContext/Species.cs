using PetFamily.Domain.Shared;
using Entity = PetFamily.Domain.Shared.Entity<PetFamily.Domain.SpeciesContext.SpeciesId>;

namespace PetFamily.Domain.SpeciesContext;

public class Species : Entity
{
    private readonly List<Breed> _breeds = [];
    
    private Species(SpeciesId id) : base(id) { }

    private Species(SpeciesId id, string name) : base(id)
    {
        Name = name;
    }
    
    public string Name { get; private set; } = string.Empty;
    
    public IReadOnlyList<Breed> Breeds => _breeds.AsReadOnly();

    public Result AddBreed(BreedId breedId, string breedName)
    {
        if (string.IsNullOrWhiteSpace(breedName))
        {
            return Result.Failure("BreedName cannot be empty");
        }

        if (_breeds.Any(b => b.Name.Equals(breedName, StringComparison.OrdinalIgnoreCase)))
        {
            return Result.Failure($"Breed '{breedName}' has already been added to this species.");
        }

        var breedResult = Breed.Create(breedId, breedName);

        if (breedResult.IsFailure)
        {
            return Result.Failure(breedResult.Error);
        }
        
        _breeds.Add(breedResult.Value);

        return Result.Success();
    }
    
    public static Result<Species> Create(SpeciesId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return "Name cannot be empty";
        }

        return new Species(id, name);
    }
}