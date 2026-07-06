namespace PetFamily.Domain.ValueObjects;

public record SocialNetwork
{
    private SocialNetwork() { } 

    public SocialNetwork(string name, string url)
    {
        Name = name;
        Url = url;
    }

    public string Name { get; init; } = string.Empty;
    public string Url { get; init; } = string.Empty;
}