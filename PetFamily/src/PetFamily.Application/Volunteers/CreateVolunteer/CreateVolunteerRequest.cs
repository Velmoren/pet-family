namespace PetFamily.Application.Volunteers.CreateVolunteer;

public record CreateVolunteerRequest(
    string FirstName,
    string LastName,
    string MiddleName,
    string Biography,
    string PhoneNumber,
    string? Email,
    int? ExperienceYears
);