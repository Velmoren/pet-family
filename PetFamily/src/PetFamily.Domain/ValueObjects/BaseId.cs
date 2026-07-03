namespace PetFamily.Domain.Shared;

public class BaseId 
{
    private BaseId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }
    
    public static BaseId NewId() => new(Guid.NewGuid());

    public static BaseId Empty() => new(Guid.Empty);
}