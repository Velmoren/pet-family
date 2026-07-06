using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteerController : Controller
{
    [HttpGet]
    public IActionResult Get(string firstName, string description)
    {
        var id = Guid.NewGuid();
        
        var volunteerResult = Volunteer.Create(VolunteerId.NewId(), firstName, description);

        if (volunteerResult.IsFailure)
        {
            return BadRequest(volunteerResult.Error);
        }
        
        var result = Save(volunteerResult.Value);

        if (result.IsFailure)
        {
            return BadRequest(volunteerResult.Error);
        }

        return Ok();
    }
    
    public Result Save(Volunteer volunteer)
    {
        if (volunteer != null)
        {
            return Result.Success();
        }

        return Result.Failure("error");
    }
}

