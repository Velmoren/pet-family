using PetFamily.Domain.Shared;

namespace PetFamily.Domain.SpeciesContext;

public class Species : Entity<SpeciesId>
{
    private readonly List<Breed> _breeds = [];

    private Species(SpeciesId id) : base(id)
    {
    }

    private Species(SpeciesId id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; } = string.Empty;

    public IReadOnlyList<Breed> Breeds => _breeds.AsReadOnly();

    public Result<List<Breed>> AddBreed(BreedId breedId, string breedName)
    {
        if (string.IsNullOrWhiteSpace(breedName))
        {
            return Errors.General.ValueIsRequired("BreedName");
        }

        if (_breeds.Any(b => b.Name.Equals(breedName, StringComparison.OrdinalIgnoreCase)))
        {
            return Errors.General.ValueIdInvalid("BreedName");
        }

        var breedResult = Breed.Create(breedId, breedName);

        if (breedResult.IsFailure)
        {
            return Errors.General.ValueIdInvalid("BreedName");
        }

        _breeds.Add(breedResult.Value);

        return _breeds;
    }

    public static Result<Species> Create(SpeciesId id, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Errors.General.ValueIsRequired("Name");
        }

        return new Species(id, name);
    }
}