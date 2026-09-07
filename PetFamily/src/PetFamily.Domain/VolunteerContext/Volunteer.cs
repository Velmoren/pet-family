using PetFamily.Domain.Shared;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.VolunteerContext;

public sealed class Volunteer : Entity<VolunteerId>
{
    private readonly List<SocialNetwork> _socialNetwork = [];

    private readonly List<PaymentRequisite> _donationDetails = [];

    private readonly List<Pet> _ownedPets = [];

    private Volunteer(VolunteerId id) : base(id)
    {
    }

    public Volunteer(VolunteerId volunteerId, VolunteerInfo volunteerInfo, PhoneNumber phoneNumber, Email? emailAddress) : base(volunteerId)
    {
        VolunteerInfo = volunteerInfo;
        PhoneNumber = phoneNumber;

        if (emailAddress != null)
        {
            EmailAddress = emailAddress;
        }
   
    }

    public VolunteerInfo VolunteerInfo { get; set; }

    public PhoneNumber PhoneNumber { get; private set; }

    public Email EmailAddress { get; private set; }

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
        var paymentRequisite = PaymentRequisite.Create(name, detail);

        _donationDetails.Add(paymentRequisite.Value);
    }

    public Result AddPet(Pet pet)
    {
        // валидация
        _ownedPets.Add(pet);

        return Result.Success();
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

    public static Result<Volunteer> Create(VolunteerId volunteerId, VolunteerInfo volunteerInfo, PhoneNumber phoneNumber, Email? emailAddress)
    {
        return new Volunteer(volunteerId, volunteerInfo, phoneNumber, emailAddress);
    }
}