using Microsoft.EntityFrameworkCore;
using PetFamily.Application.Volunteers;
using PetFamily.Domain.Shared;
using PetFamily.Domain.ValueObjects;
using PetFamily.Domain.VolunteerContext;

namespace PetFamily.Infrastructure.Repositories;

// Можно как в primary конструкторе добавить, так и создать private поле.
// Через primary - современный способ
public class VolunteersRepository(ApplicationDbContext dbContext) : IVolunteersRepository
{
    // private readonly ApplicationDbContext _dbContext;
    //
    // public VolunteerRepository(ApplicationDbContext dbContext)
    // {
    //     _dbContext = dbContext;
    // }

    public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
    {
        await dbContext.Volunteers.AddAsync(volunteer, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return volunteer.Id;
    }

    public async Task<Result<List<Volunteer>>> Get(CancellationToken cancellationToken = default)
    {
        var volunteers = await dbContext.Volunteers.ToListAsync(cancellationToken);
        
        return volunteers;
    }

    public async Task<Result<Volunteer>> GetById(VolunteerId volunteerId, CancellationToken cancellationToken = default)
    {
        var volunteer = await dbContext.Volunteers
            .Include(v => v.OwnedPets)
            // .ThenInclude(p => p.) // Если нужно джоинить еще глубже и выстроить цепочку джоинов
            .FirstOrDefaultAsync(v => v.Id == volunteerId, cancellationToken);

        if (volunteer is null)
        {
            return Errors.General.NotFound(volunteerId);
        }

        return volunteer;
    }

    public async Task<Result<Volunteer>> GetByPhoneNumber(PhoneNumber phoneNumber, CancellationToken cancellationToken)
    {
        var volunteer = await dbContext.Volunteers
            .Include(v => v.OwnedPets)
            .FirstOrDefaultAsync(v => v.PhoneNumber == phoneNumber, cancellationToken);

        if (volunteer is null)
        {
            return Errors.General.NotFound();
        }

        return volunteer;
    }
}