using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using PetFamily.Domain.Volunteer;

namespace PetFamily.API.Controllers;

public class PetController : Controller
{
    [HttpGet]
    public IActionResult Get(string name, string description)
    {
        Result<Pet> petResult = Pet.Create(name, description);

        if (petResult.IsFailure)
        {
            return BadRequest(petResult.Error);
        }
        
        var result = Save(petResult.Value);

        if (result.IsFailure)
        {
            return BadRequest(petResult.Error);
        }

        return Ok();
    }
    
    public Result Save(Pet pet)
    {
        if (pet != null)
        {
            return Result.Success();
        }

        return Result.Failure("error");
    }
}

