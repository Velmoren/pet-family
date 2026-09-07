using PetFamily.Domain.Shared;
using PetFamily.Domain.VolunteerContext;

namespace PetFamily.Application.Volunteers.GetByIdVolunteer;

public class GetByIdVolunteerHandler
{
    private readonly IVolunteersRepository _volunteersRepository;

    public GetByIdVolunteerHandler(IVolunteersRepository volunteersRepository)
    {
        _volunteersRepository = volunteersRepository;
    }

    public async Task<Result<Volunteer>> Handle(
        GetByIdVolunteerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var volunteer = await _volunteersRepository.GetById(request.id, cancellationToken);

        return volunteer;
    }
}