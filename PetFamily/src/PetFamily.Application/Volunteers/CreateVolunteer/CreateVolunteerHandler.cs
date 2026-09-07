using PetFamily.Domain.Shared;
using PetFamily.Domain.ValueObjects;
using PetFamily.Domain.VolunteerContext;

namespace PetFamily.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerHandler
{
    private readonly IVolunteersRepository _volunteersRepository;

    public CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
    {
        _volunteersRepository = volunteersRepository;
    }

    public async Task<Result<Guid>> Handle(
        CreateVolunteerRequest request, CancellationToken cancellationToken = default)
    {
        // валидация
        var phoneNumber = PhoneNumber.Create(request.PhoneNumber);

        if (phoneNumber.IsFailure) return phoneNumber.Error!;

        var email = Email.Create(request.Email);

        if (email.IsFailure) return email.Error!;

        // получить волонтера с названием request.LastName
        // если такой волонтер существует то вернуть ошибку
        var volunteer = await _volunteersRepository.GetByPhoneNumber(phoneNumber.Value, cancellationToken);

        if (volunteer.IsSuccess)
        {
            return Errors.Volunteer.AlreadyExist();
        }

        // создание доменной модели
        var volunteerId = VolunteerId.NewId();

        var volunteerInfo = VolunteerInfo.Create(
            request.FirstName,
            request.LastName,
            request.MiddleName,
            request.Biography,
            request.ExperienceYears
        );

        if (volunteerInfo.IsFailure) return volunteerInfo.Error!;

        var volunteerResult = new Volunteer(volunteerId, volunteerInfo.Value, phoneNumber.Value, email.Value);

        // сохранение в базу данных
        await _volunteersRepository.Add(volunteerResult, cancellationToken);

        return (Guid)volunteerResult.Id; // volunteerId.Value;
    }
}