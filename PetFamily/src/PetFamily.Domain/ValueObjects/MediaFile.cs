using PetFamily.Domain.Shared;

namespace PetFamily.Domain.ValueObjects;

public record MediaFile
{
    public string StoragePath { get; } = string.Empty;

    private MediaFile(string storagePath)
    {
        StoragePath = storagePath;
    }

    public static Result<MediaFile> Create(string storagePath)
    {
        if (string.IsNullOrWhiteSpace(storagePath))
        {
            return Errors.General.ValueIsRequired("StoragePath");
        }

        return new MediaFile(storagePath);
    }
}