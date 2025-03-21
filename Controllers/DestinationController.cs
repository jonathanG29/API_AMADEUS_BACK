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
    public async Task<ActionResult> GetDestination(int id)
    {
        var destination = await destinationService.GetDestinationById(id);

        if (destination == null)
        {
            return NotFound(new { Message = "Destination not found", StatusCode = 404 });
        }

        return Ok(destination);
    }

}
