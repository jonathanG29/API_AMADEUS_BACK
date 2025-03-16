using API_AMADEUS.Data;
using API_AMADEUS.Models;
using API_AMADEUS.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_AMADEUS.Controllers;

[Route("api/[controller]")]
public class UserController(ApplicationDbContext context) : ControllerBase {

    private readonly UserService userService = new(context);

    [HttpGet]
    public async Task<IActionResult> GetUsers(){
        
        var User = await UserService.GetAllUsers();
        return Ok(User);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id) {
        var User = await UserService.GetUserById(id);

        if (User == null) {
            return NotFound(new ErrorResponse {Message = "User not found", StatusCode = 404});
        }

        return User;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user) {
        
        var CreateUser = await UserService.CreateUser(User);

        if (CreateUser == null) {
            return NotFound(new ErrorResponse {Message = "USER NOT BEEN CREATED", StatusCode = 404});
        }

        return CreatedAtAction("GetUser", new { id = CreateUser.Id }, CreateUser);
    }

}