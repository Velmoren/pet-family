namespace PetFamily.Domain.ValueObjects;

public abstract record BaseId 
{
    protected BaseId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }
}