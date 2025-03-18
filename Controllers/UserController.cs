using API_AMADEUS.Data;
using API_AMADEUS.Models;
using API_AMADEUS.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_AMADEUS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(ApplicationDbContext context) : ControllerBase {

    private readonly UserService userService = new(context);

    [HttpGet]
    public async Task<IActionResult> GetUsers(){

        var users = await userService.GetAllUsers();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetUser(int id) {
        var user = await userService.GetUserById(id);

        if (user == null) {
            return NotFound(new ErrorResponse {Message = "User not found", StatusCode = 404});
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user) {
        try
        {
            var createdUser = await userService.CreateUser(user);
            return CreatedAtAction("GetUser", new { id = createdUser.Id }, createdUser);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new ErrorResponse { Message = ex.Message, StatusCode = 400 });
        }
    }
}