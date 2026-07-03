using CSharpFunctionalExtensions;
using Microsoft.VisualBasic.CompilerServices;

namespace PetFamily.Domain.Volunteers;

public record PetPhoto
{
    private PetPhoto(string path)
    {
        StoragePath = path;
    }
    
    public string StoragePath { get; } = string.Empty;
    
    public bool IsMain { get; }

    public static Result<PetPhoto> Create(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return Result.Failure<PetPhoto>("Path cannot be empty");
        }

        return Result.Success(new PetPhoto(path));
    }
}