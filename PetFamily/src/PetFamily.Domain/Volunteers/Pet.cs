using CSharpFunctionalExtensions;
using PetFamily.Domain.Enums;
using PetFamily.Domain.ValueObjects;

using Entity = PetFamily.Domain.Shared.Entity<PetFamily.Domain.Volunteers.PetId>;

namespace PetFamily.Domain.Volunteers;

public class Pet : Entity
{
    private readonly List<PaymentRequisite> _donationDetails = [];
    
    private readonly List<PetPhoto> _petPhotos = [];
    
    private Pet(PetId petId) : base(petId)
    {
    }
    
    private Pet(PetId petId, string name, string description) : base(petId)
    {
        Name = name;
        Description = description;
    }
    
    public VolunteerId VolunteerId { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string Name { get; private set; }
    
    public string Description { get; private set; }

    public string Species { get; private set; }
    
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

    public void AddDonationDetail(string name, string detail)
    {
        // валидация
        var paymentRequisite = new PaymentRequisite(name, detail);
        
        _donationDetails.Add(paymentRequisite);
    }
    
    public void AddPetPhoto(PetPhoto petPhoto)
    {
  
    }

    public static Result<Pet> Create(PetId id, VolunteerId volunteerId, string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Pet>("Name cannot be empty");
        }

        if (string.IsNullOrEmpty(description))
        {
            return Result.Failure<Pet>("Description cannot be empty");
        }

        var pet = new Pet(id, name, description);

        return Result.Success(pet);
    }
}