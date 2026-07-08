using Microsoft.AspNetCore.Mvc;
using PetFamily.Domain.VolunteerContext;

namespace PetFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteerController : Controller
{
    [HttpGet]
    public IActionResult Get(string firstName, string description)
    {
        
        var volunteerResult = Volunteer.Create(VolunteerId.NewId(), firstName, description);

        if (volunteerResult.IsFailure)
        {
            return BadRequest(volunteerResult.Error);
        }

        return Ok();
    }
}

