namespace PetFamily.Application.Volunteers.UpdateVolunteer;

public record UpdateVolunteerCommand(Guid Id, UpdateVolunteerDto UpdateVolunteerDto);

public record UpdateVolunteerDto(
    string FirstName,
    string LastName,
    string MiddleName,
    string Biography,
    int? ExperienceYears
);