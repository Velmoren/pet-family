using CSharpFunctionalExtensions;
using PetFamily.Domain.ValueObjects;

using Entity = PetFamily.Domain.Shared.Entity<PetFamily.Domain.Volunteers.VolunteerId>;

namespace PetFamily.Domain.Volunteers;

public sealed class Volunteer : Entity
{
    private readonly List<SocialNetwork> _socialNetwork = [];

    private readonly List<PaymentRequisite> _donationDetails = [];

    private readonly List<Pet> _ownedPets = [];

    private Volunteer(VolunteerId id) : base(id)
    {
    }

    private Volunteer(VolunteerId volunteerId, string firstName, string biography) : base(volunteerId)
    {
        FirstName = firstName;
        Biography = biography;
    }

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

    public void AddSocialNetwork(SocialNetwork socialNetwork)
    {
        // валидация
        _socialNetwork.Add(socialNetwork);
    }

    public void AddDonationDetail(string name, string detail)
    {
        // валидация
        var paymentRequisite = new PaymentRequisite(name, detail);
        
        _donationDetails.Add(paymentRequisite);
    }

    public void AddPet(Pet pet)
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

    public static Result<Volunteer> Create(VolunteerId volunteerId, string firstName, string biography)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<Volunteer>("First name cannot be empty");
        }

        if (string.IsNullOrWhiteSpace(biography))
        {
            return Result.Failure<Volunteer>("Biography cannot be empty");
        }

        var volunteer = new Volunteer(volunteerId, firstName, biography);

        return Result.Success(volunteer);
    }
}