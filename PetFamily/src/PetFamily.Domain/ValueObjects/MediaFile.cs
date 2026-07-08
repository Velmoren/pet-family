using PetFamily.Domain.Shared;

namespace PetFamily.Domain.ValueObjects;

public record MediaFile
{
    public string StoragePath { get; init; } = string.Empty;

    private MediaFile(string storagePath)
    {
        StoragePath = storagePath;
    }

    public static Result<MediaFile> Create(string storagePath)
    {
        if (string.IsNullOrWhiteSpace(storagePath))
        {
            return "Storage path cannot be empty.";
        }

        return new MediaFile(storagePath);
    }
}