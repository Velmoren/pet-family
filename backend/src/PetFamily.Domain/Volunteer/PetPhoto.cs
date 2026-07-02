using Microsoft.VisualBasic.CompilerServices;

namespace PetFamily.Domain.Volunteer;

public class PetPhoto
{
    public string StoragePath { get; set; } = string.Empty;
    
    public bool IsMain { get; set; }
}