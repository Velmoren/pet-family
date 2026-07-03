using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Volunteers;

public class Volunteer : Shared.Entity<BaseId>
{
    private readonly List<SocialNetwork> _socialNetwork = [];

    private readonly List<PaymentRequisite> _donationDetails = [];

    private readonly List<Pet> _ownedPets = [];

    private Volunteer(BaseId id) : base(id)
    {
    }

    private Volunteer(BaseId volunteerId, string firstName, string biography) : base(volunteerId)
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

    public static Result<Volunteer> Create(BaseId volunteerId, string firstName, string biography)
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