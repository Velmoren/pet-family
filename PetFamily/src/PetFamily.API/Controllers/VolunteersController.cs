using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Extensions;
using PetFamily.Application.Volunteers.CreateVolunteer;
using PetFamily.Application.Volunteers.GetByIdVolunteer;
using PetFamily.Application.Volunteers.GetVolunteer;
using PetFamily.Application.Volunteers.UpdateVolunteer;

namespace PetFamily.API.Controllers;

public class VolunteersController : ApplicationController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateVolunteerHandler handler,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result = await handler.Handle(request, cancellationToken);

        if (result.IsFailure) return result.Error.ToResponse();

        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] GetVolunteerHandler handler,
        CancellationToken cancellationToken = default
    )
    {
        var result = await handler.Handle(cancellationToken);

        return Ok(result.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(
        [FromServices] GetByIdVolunteerHandler handler,
        [FromRoute] GetByIdVolunteerRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var result = await handler.Handle(request, cancellationToken);
        
        if (result.IsFailure) return result.Error.ToResponse();
        
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