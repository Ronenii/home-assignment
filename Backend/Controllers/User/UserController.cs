﻿using Backend.DTO.User;
using Backend.Services.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.User;

[Route("api/[controller]")]
[ApiController]
public class UserController: Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<UserDTO>))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetAllUsers()
    {
        IEnumerable<UserDTO> users = await _userService.GetAllUsers();
        return Ok(users);
    }
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<UserDTO>))]
    public async Task<IActionResult> GetUserById(int id)
    {
        UserDTO user = await _userService.GetUserById(id);
        if(user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}