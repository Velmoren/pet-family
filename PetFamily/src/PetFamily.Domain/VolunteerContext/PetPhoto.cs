using CSharpFunctionalExtensions;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.VolunteerContext;

public record PetPhoto
{
    public MediaFile File { get; init; }
    public bool IsMain { get; init; }
    
    private PetPhoto() { }

    private PetPhoto(MediaFile file, bool isMain)
    {
        File = file;
        IsMain = isMain;
    }

    public static Result<PetPhoto> Create(MediaFile file, bool isMain = false)
    {
        if (file == null)
        {
            return Result.Failure<PetPhoto>("File info cannot be null.");
        }

        return Result.Success(new PetPhoto(file, isMain));
    }
}