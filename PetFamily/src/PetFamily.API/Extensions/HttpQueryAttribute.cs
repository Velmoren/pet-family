using Microsoft.AspNetCore.Mvc.Routing;

namespace PetFamily.API.Extensions;

public class HttpQueryAttribute : HttpMethodAttribute
{
    private static readonly IEnumerable<string> SupportedMethods = new[] { "QUERY" };

    public HttpQueryAttribute() : base(SupportedMethods) { }
    public HttpQueryAttribute(string template) : base(SupportedMethods, template) { }
}