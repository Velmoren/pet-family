using System.Text.RegularExpressions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.ValueObjects;

public partial record SocialNetwork
{
    // Генератор регулярного выражения для проверки ссылки
    [GeneratedRegex(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$", RegexOptions.IgnoreCase, 1000)]
    private static partial Regex UrlRegex();

    public string Name { get; }
    public string Url { get; }

    private SocialNetwork(string name, string url)
    {
        Name = name;
        Url = url;
    }

    public static Result<SocialNetwork> Create(string name, string url)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(name))
            errors.Add("Название социальной сети не может быть пустым.");

        if (string.IsNullOrWhiteSpace(url))
        {
            errors.Add("Ссылка на социальную сеть не может быть пустой.");
        }
        else if (!UrlRegex().IsMatch(url.Trim()))
        {
            errors.Add("Неверный формат ссылки на социальную сеть.");
        }

        if (errors.Any())
        {
            return Errors.General.ValueIdInvalid(string.Join(" ", errors));
        }

        return new SocialNetwork(name.Trim(), url.Trim());
    }
}