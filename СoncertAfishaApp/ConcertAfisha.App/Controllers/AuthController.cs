using ConcertAfisha.Application.DTOs.User;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Application.UseCases.RefreshToken;
using ConcertAfisha.Application.UseCases.User;
using ConcertAfisha.Core.Abstractions.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ConcertAfishaApp.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtTokenService _jwtTokenService;
    private readonly LoginUserUseCase _loginUserUseCase;
    private readonly GetUserByIdUseCase _getUserByIdUseCase;
    private readonly RefreshRefreshTokenUseCase _refreshRefreshTokenUseCase;
    private readonly GetRefreshTokenUseCase _getRefreshTokenUseCase;

    public AuthController(IJwtTokenService jwtTokenService,
        LoginUserUseCase loginUserUseCase,
        GetUserByIdUseCase getUserByIdUseCase,
         RefreshRefreshTokenUseCase refreshRefreshTokenUseCase, GetRefreshTokenUseCase getRefreshTokenUseCase)
    {
        _jwtTokenService = jwtTokenService;
        _loginUserUseCase = loginUserUseCase;
        _getUserByIdUseCase = getUserByIdUseCase;
        _refreshRefreshTokenUseCase = refreshRefreshTokenUseCase;
        _getRefreshTokenUseCase = getRefreshTokenUseCase;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto request)
    {
        try
        {
            var user = await _loginUserUseCase.Execute(request);
            var tokens = await _jwtTokenService.GenerateToken(user.Id, user.Role);
            HttpContext.Response.Cookies.Append("refresh_token", tokens.Item2);
            var tokensResponse = new TokensResponse(tokens.Item1, tokens.Item2);
            return Ok(new { user = user, tokensResponse });
        }
        catch (Exception e)
        {
            return Unauthorized(e.Message);
        }
    }

    [HttpGet("refresh")]
    public async Task<IActionResult> RefreshToken()
    {
        string? refreshToken = Request.Cookies["refresh_token"];
        if (string.IsNullOrEmpty(refreshToken))
        {
            return Unauthorized("Refresh token is empty");
        }

        try
        {
            var tokens = await _refreshRefreshTokenUseCase.Execute(refreshToken);
            HttpContext.Response.Cookies.Append("refresh_token", tokens.Item2);
            var tokensResponse = new TokensResponse(tokens.Item1, tokens.Item2);
            var rt = await _getRefreshTokenUseCase.Execute(refreshToken);
            var user = await _getUserByIdUseCase.Execute(rt.UserId);

            return Ok(new { user, tokensResponse });
        }
        catch (NotFoundException e)
        {
            return NotFound(new { Message = e.Message });
        }
        catch (InvalidCastException e)
        {
            return BadRequest(new { Message = e.Message });
        }
    }
}