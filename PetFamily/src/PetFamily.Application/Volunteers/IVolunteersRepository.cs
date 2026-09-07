using PetFamily.Domain.Shared;
using PetFamily.Domain.ValueObjects;
using PetFamily.Domain.VolunteerContext;

namespace PetFamily.Application.Volunteers;

public interface IVolunteersRepository
{
    Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default);
    
    Task<Result<List<Volunteer>>> Get(CancellationToken cancellationToken = default);
    
    Task<Result<Volunteer>> GetById(VolunteerId volunteerId, CancellationToken cancellationToken = default);
    
    Task<Result<Volunteer>> GetByPhoneNumber(PhoneNumber phoneNumber, CancellationToken cancellationToken = default);
}