using CSharpFunctionalExtensions;
using PetFamily.Domain.Emuns;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Volunteer;

public class Pet
{
    public Pet(string name, string description)
    {
        Name = name;
        Description = description;
    }
    
    private readonly List<PaymentRequisite> _donationDetails = [];
    
    private readonly List<PetPhoto> _petPhotos = [];

    public Guid Id { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string Name { get; private set; }

    public Species Species { get; private set; }
    public string Description { get; private set; }

    public Breed Breed { get; private set; }

    public string HealthInfo { get; private set; } = string.Empty;

    public string LocationAddress { get; private set; } = string.Empty;

    public PhoneNumber ContactPhone { get; private set; }

    public HelpStatus HelpStatus { get; private set; }

    public DateTime? BirthDate { get; private set; } = null;

    public double Weight { get; private set; } = 0;

    public double Height { get; private set; } = 0;

    public bool IsNeutered { get; private set; } = false;

    public bool IsVaccinated { get; private set; } = false;

    public IReadOnlyList<PaymentRequisite> DonationDetails => _donationDetails.AsReadOnly();
    
    public IReadOnlyList<PetPhoto> PetPhotos => _petPhotos.AsReadOnly();

    public void AddDonationDetail(string detail)
    {
        _donationDetails.Add(new PaymentRequisite { Detail = detail });
    }
    
    public void AddPetPhoto(PetPhoto petPhoto)
    {
        _petPhotos.Add(new PetPhoto());
    }

    public static Result<Pet> Create(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Pet>("Name cannot be empty");
        }

        if (string.IsNullOrEmpty(description))
        {
            return Result.Failure<Pet>("Description cannot be empty");
        }

        var pet = new Pet(name, description);

        return Result.Success(pet);
    }
}