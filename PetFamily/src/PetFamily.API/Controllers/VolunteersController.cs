using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Extensions;
using PetFamily.Application.Volunteers.CreateVolunteer;
using PetFamily.Application.Volunteers.UpdateVolunteer;
using PetFamily.Domain.ValueObjects;
using PetFamily.Domain.VolunteerContext;

namespace PetFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteersController : Controller
{
    [HttpGet]
    public IActionResult Get(Guid id)
    {
        var file = MediaFile.Create("Test").Value;

        List<MediaFile> fileList = [file, file, file];

        return Ok(fileList);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateVolunteerRequest request)
    {
        var volunteerResult = Volunteer.Create(
            VolunteerId.NewId(),
            VolunteerInfo.Create(
                request.FirstName,
                request.LastName,
                request.MiddleName,
                request.Biography,
                request.ExperienceYears
            ).Value);

        if (volunteerResult.IsFailure)
        {
            return BadRequest(volunteerResult.Error);
        }

        return Ok();
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateVolunteerDto dto)
    {
        var request = new UpdateVolunteerCommand(id, dto);
 
        return Ok();
    }
    
    [HttpQuery]
    public IActionResult Search([FromRoute] Guid id, [FromBody] UpdateVolunteerDto dto)
    {
        var request = new UpdateVolunteerCommand(id, dto);
 
        return Ok();
    }
};