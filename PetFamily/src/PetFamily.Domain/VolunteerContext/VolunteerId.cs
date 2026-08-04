using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.VolunteerContext;

public record VolunteerId : BaseId
{
    private VolunteerId(Guid value) : base(value)
    {
    }

    public static VolunteerId NewId() => new(Guid.NewGuid());

    public static VolunteerId Empty() => new(Guid.Empty);

    public static VolunteerId Create(Guid id) => new(id);

    // Специальная перегрузка опрератора для сокращенного обращения к Id
    // Volunteer.Id.Value => Volunteer.Id
    public static implicit operator VolunteerId(Guid id) => new VolunteerId(id);

    public static implicit operator Guid(VolunteerId id)
    {
        ArgumentNullException.ThrowIfNull(id);

        return id.Value;
    }
}