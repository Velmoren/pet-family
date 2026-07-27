using PetFamily.Domain.Shared;

namespace PetFamily.Domain.ValueObjects;

public record VolunteerInfo
{
    public string FirstName { get; }

    public string LastName { get; }

    public string MiddleName { get; }

    public string Biography { get; }
    
    public int? ExperienceYears { get; }
    
    private VolunteerInfo(string firstName, string lastName, string middleName, string biography, int? experienceYears)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Biography = biography;
        ExperienceYears = experienceYears;
    }

    public static Result<VolunteerInfo> Create(string firstName, string lastName, string middleName, string biography, int? experienceYears)
    {
        var errors = new List<string>();
        
        if (string.IsNullOrWhiteSpace(firstName))
            errors.Add("Имя волонтера не может быть пустым.");
        else if (firstName.Length > 100)
            errors.Add("Имя не может превышать 100 символов.");

        // 2. Валидация Фамилии
        if (string.IsNullOrWhiteSpace(lastName))
            errors.Add("Фамилия волонтера не может быть пустой.");
        else if (lastName.Length > 100)
            errors.Add("Фамилия не может превышать 100 символов.");

        // 3. Валидация Отчества (необязательное поле)
        if (!string.IsNullOrWhiteSpace(middleName) && middleName.Length > 100)
            errors.Add("Отчество не может превышать 100 символов.");

        // 4. Валидация Биографии
        if (string.IsNullOrWhiteSpace(biography))
            errors.Add("Биография не может быть пустой.");
        else if (biography.Length > 2000)
            errors.Add("Биография не может превышать 2000 символов.");
        
        // 5. Валидация Опыта
        if (experienceYears.HasValue)
        {
            if (experienceYears.Value < 0)
                errors.Add("Опыт работы не может быть отрицательным числом.");
            else if (experienceYears.Value > 80)
                errors.Add("Указан нереалистичный опыт работы.");
        }

        // Если есть хоть одна ошибка — склеиваем их и возвращаем через неявное приведение типов Result
        if (errors.Any())
        {
            return string.Join(" ", errors);
        }
        
        return new VolunteerInfo(
            firstName.Trim(), 
            lastName.Trim(), 
            middleName?.Trim() ?? string.Empty, // Защищаем от null, если отчество не передано
            biography.Trim(), 
            experienceYears);
    }
}