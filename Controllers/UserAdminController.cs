using API_AMADEUS.Data;
using API_AMADEUS.DTOs;
using API_AMADEUS.Models;
using API_AMADEUS.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_AMADEUS.controllers;

[ApiController]
[Route("api/[controller]")]
public class UserAdminController : ControllerBase
{
    private readonly UserAdminService userService;

    public UserAdminController(ApplicationDbContext context)
    {
        userService = new UserAdminService(context);
    }

    // Endpoint para obtener solo administradores
    [HttpGet("admins")]
    public async Task<IActionResult> GetAdmins()
    {
        var admins = await userService.GetAllAdmins();
        var adminDTOs = admins.Select(admin => new UserAdminDTO
        {
            Id = admin.Id,
            username = admin.username,
            user_password = admin.user_password
        }).ToList();

        return Ok(adminDTOs);
    }
}
