using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Volunteer;

public class Volunteer
{
    public Volunteer(string firstName, string biography)
    {
        FirstName = firstName;
        Biography = biography;
    }
    
    private readonly List<SocialNetwork> _socialNetwork = [];
    
    private readonly List<PaymentRequisite> _donationDetails = [];
    
    private readonly List<Pet> _ownedPets = [];

    public Guid Id { get; private set; }
    
    public string FirstName { get; private set; }
    
    public string LastName { get; private set; }
    
    public string MiddleName { get; private set; }
    
    public string Biography { get; private set; }
    
    public string PhoneNumber { get; private set; }
    
    public Email EmailAddress { get; private set; }
    
    public int ExperienceYears { get; private set; }

    public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetwork.AsReadOnly();
    
    public IReadOnlyList<PaymentRequisite> DonationDetails => _donationDetails.AsReadOnly();
    
    public IReadOnlyList<Pet> OwnedPets => _ownedPets.AsReadOnly();

    public void UpdateSocialNetwork(SocialNetwork socialNetwork)
    {
        // валидация
        _socialNetwork.Add(socialNetwork);
    }
    
    public void AddDonationDetail(string detail)
    {
        // валидация
        _donationDetails.Add(new PaymentRequisite { Detail = detail });
    }
    
    public void UpdateOwnedPets(Pet pet)
    {
        // валидация
        _ownedPets.Add(pet);
    }

    public int GetAdoptedPetsCount()
    {
        return 0;
    }
    
    public int GetSearchingPetsCount()
    {
        return 0;
    }
    
    public int GetUnderTreatmentPetsCount()
    {
        return 0;
    }
}