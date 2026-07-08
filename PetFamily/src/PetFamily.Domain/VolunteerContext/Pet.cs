using PetFamily.Domain.Enums;
using PetFamily.Domain.Shared;
using PetFamily.Domain.ValueObjects;
using PetFamily.Domain.SpeciesContext;

using Entity = PetFamily.Domain.Shared.Entity<PetFamily.Domain.VolunteerContext.PetId>;

namespace PetFamily.Domain.VolunteerContext;

public class Pet : Entity
{
    private readonly List<PaymentRequisite> _donationDetails = [];
    
    private readonly List<PetPhoto> _petPhotos = [];
    
    private Pet(PetId id) : base(id)
    {
    }
    
    private Pet(PetId id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }
    
    public VolunteerId VolunteerId { get; private set; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string Name { get; private set; }
    
    public string Description { get; private set; }

    public SpeciesId SpeciesId { get; private set; }
    
    public BreedId BreedId { get; private set; }

    public string HealthInfo { get; private set; } = string.Empty;

    public Address LocationAddress { get; private set; }

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
            return "Name cannot be empty";
        }

        if (string.IsNullOrEmpty(description))
        {
            return "Description cannot be empty";
        }

        return new Pet(id, name, description);
    }
}