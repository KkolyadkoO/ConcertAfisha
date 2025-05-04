using ConcertAfisha.Application.DTOs.User;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Application.UseCases.RefreshToken;
using ConcertAfisha.Application.UseCases.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConcertAfishaApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly RegisterUserUseCase _registerUserUseCase;
    private readonly GetAllUsersUseCase _getAllUsersUseCase;
    private readonly DeleteRefreshTokenUseCase _deleteRefreshTokenUseCase;
    private readonly UpdateUserUseCase _updateUserUseCase;

    public UserController(RegisterUserUseCase registerUserUseCase,
        GetAllUsersUseCase getAllUsersUseCase,
        DeleteRefreshTokenUseCase deleteRefreshTokenUseCase,
        UpdateUserUseCase updateUserUseCase)
    {
        _registerUserUseCase = registerUserUseCase;
        _getAllUsersUseCase = getAllUsersUseCase;
        _deleteRefreshTokenUseCase = deleteRefreshTokenUseCase;
        _updateUserUseCase = updateUserUseCase;
    }
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegisterRequestDto request)
    {
        try
        {
            await _registerUserUseCase.Execute(request);
            return Ok();
        }
        catch (DuplicateException e)
        {
            return BadRequest(new { Message = e.Message });
        }
        
    }
    
    [HttpGet]
    [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await _getAllUsersUseCase.Execute();
        return Ok(response);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        string? refreshToken = Request.Cookies["refresh_token"];
        if (refreshToken == null)
        {
            return NotFound(new { message = "Refresh token not found in cookies" });
        }

        try
        {
            await _deleteRefreshTokenUseCase.Execute(refreshToken);
            Response.Cookies.Delete("refresh_token");
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
        
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserRegisterRequestDto request)
    {
        try
        {
            await _updateUserUseCase.Execute(id, request);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }
}