using API_AMADEUS.Data;
using API_AMADEUS.Models;
using API_AMADEUS.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_AMADEUS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionOptionController(ApplicationDbContext context) : ControllerBase
{
    private readonly QuestionOptionService _service = new(context);

    [HttpGet]
    public async Task<IActionResult> GetAllOptions()
    {
        var options = await _service.GetAllOptions();
        return Ok(options);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOption(int id)
    {
        var option = await _service.GetOptionById(id);
        if (option == null)
        {
            return NotFound(new { message = "Option not found" });
        }
        return Ok(option);
    }
}
