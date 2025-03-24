using API_AMADEUS.Data;
using API_AMADEUS.Models;
using API_AMADEUS.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_AMADEUS.Controllers;

[Route("api/[controller]")]
public class UserController : ControllerBase {

    private readonly UserService userService;

    public UserController(ApplicationDbContext context) {
        userService = new UserService(context);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers(){
        var users = await userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id) {
        var user = await userService.GetUserById(id);

        if (user == null) {
            return NotFound(new ErrorResponse {Message = "User not found", StatusCode = 404});
        }

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user) {
        var createdUser = await userService.CreateUser(user);

        if (createdUser == null) {
            return NotFound(new ErrorResponse {Message = "User not been created", StatusCode = 404});
        }

        return CreatedAtAction("GetUser", new { id = createdUser.Id }, createdUser);
    }
}