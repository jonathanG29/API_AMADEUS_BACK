using API_AMADEUS.Data;
using API_AMADEUS.DTOs;
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
        var userDTOs = users.Select(user => new UserDTO
        {
            Id = user.Id,
            full_name = user.full_name,
            email = user.email,
        }).ToList();

        return Ok(userDTOs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetUser(int id) {
        var user = await userService.GetUserById(id);

        if (user == null) {
            return NotFound(new ErrorResponse {Message = "User not found", StatusCode = 404});
        }

        var userDTO = new UserDTO
        {
            Id = user.Id,
            full_name = user.full_name,
            email = user.email,
        };

        return Ok(userDTO);
    }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser(UserDTO userDTO) {
        try
        {
            var user = new User
            {
                full_name = userDTO.full_name,
                email = userDTO.email
            };

            var createdUser = await userService.CreateUser(user);

            var createdUserDTO = new UserDTO
            {
                Id = createdUser.Id,
                full_name = createdUser.full_name,
                email = createdUser.email
            };

            return CreatedAtAction("GetUser", new { id = createdUserDTO.Id }, createdUserDTO);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new ErrorResponse { Message = ex.Message, StatusCode = 400 });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new ErrorResponse { Message = ex.Message, StatusCode = 400 });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserFullName(int id, [FromBody] UserUpdateDTO userUpdateDTO)
    {
        var updatedUser = await userService.UpdateUserFullName(id, userUpdateDTO.full_name);

        if (updatedUser == null)
        {
            return NotFound(new ErrorResponse { Message = "User not found", StatusCode = 404 });
        }

        var updatedUserDTO = new UserDTO
        {
            Id = updatedUser.Id,
            full_name = updatedUser.full_name,
            email = updatedUser.email
        };

        return Ok(updatedUserDTO);
    }
}