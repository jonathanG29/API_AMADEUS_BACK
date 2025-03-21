using API_AMADEUS.Data;
using API_AMADEUS.Models;
using API_AMADEUS.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_AMADEUS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController(ApplicationDbContext context) : ControllerBase
{
    private readonly CityService cityService = new(context);

    [HttpGet]
    public async Task<IActionResult> GetCities()
    {
        var cities = await cityService.GetAllCities();
        return Ok(cities);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCity(int id)
    {
        var city = await cityService.GetCityById(id);
        if (city == null)
        {
            return NotFound(new ErrorResponse { Message = "City not found", StatusCode = 404 });
        }
        return Ok(city);
    }
}
