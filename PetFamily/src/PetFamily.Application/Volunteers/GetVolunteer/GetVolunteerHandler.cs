using PetFamily.Domain.Shared;
using PetFamily.Domain.VolunteerContext;

namespace PetFamily.Application.Volunteers.GetVolunteer;

public class GetVolunteerHandler
{
    private readonly IVolunteersRepository _volunteersRepository;
    
    public GetVolunteerHandler(IVolunteersRepository volunteersRepository)
    {
        _volunteersRepository = volunteersRepository;
    }

    public async Task<Result<List<Volunteer>>> Handle(CancellationToken cancellationToken = default)
    {
        var volunteers = await _volunteersRepository.Get(cancellationToken);
        
        return volunteers;
    }
}