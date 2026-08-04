using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Shared;
using PetFamily.Domain.VolunteerContext;

namespace PetFamily.Infrastructure.Repositories;

// Можно как в primary конструкторе добавить, так и создать private поле.
// Через primary - современный способ
public class VolunteersRepository(ApplicationDbContext dbContext)
{
    // private readonly ApplicationDbContext _dbContext;
    //
    // public VolunteerRepository(ApplicationDbContext dbContext)
    // {
    //     _dbContext = dbContext;
    // }

    public async Task<Guid> Add(Volunteer volunteer, CancellationToken ct = default)
    {
        await dbContext.Volunteers.AddAsync(volunteer, ct);

        await dbContext.SaveChangesAsync(ct);

        return volunteer.Id;
    }

    public async Task<Result<Volunteer>> GetById(VolunteerId volunteerId, CancellationToken ct = default)
    {
        var volunteer = await dbContext.Volunteers
            .Include(v => v.OwnedPets)
            // .ThenInclude(p => p.) // Если нужно джоинить еще глубже и выстроить цепочку джоинов
            .FirstOrDefaultAsync(v => v.Id == volunteerId, ct);

        if (volunteer is null)
        {
            return "Volunteer not found";
        }

        return volunteer;
    }
}