using API_AMADEUS.Data;
using API_AMADEUS.Models;
using API_AMADEUS.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_AMADEUS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DestinationController(ApplicationDbContext context) : ControllerBase
{
    private readonly DestinationService destinationService = new(context);

    [HttpGet]
    public async Task<IActionResult> GetDestinations()
    {
        var destinations = await destinationService.GetAllDestinations();
        return Ok(destinations);
    }

    [HttpGet("{id}")]
    public ActionResult GetDestinationHash(string id)
    {
        string destination = destinationService.GetDestinationHash(id);

        if (destination == null)
        {
            return NotFound(new { Message = "Destination not found", StatusCode = 404 });
        }

        return Ok(destination);
    }

    [HttpGet("combination/{combination}")]
    public async Task<IActionResult> GetDestinationByCombination(string combination)
    {
        var destination = await destinationService.GetDestinationByCombination(combination);

        if (destination == null)
        {
            return NotFound(new { Message = "Destination not found", StatusCode = 404 });
        }

        return Ok(destination);
    }

}
