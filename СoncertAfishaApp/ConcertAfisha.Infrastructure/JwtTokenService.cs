﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ConcertAfisha.Core.Abstractions.Auth;
using ConcertAfisha.Core.Abstractions.Repositories;
using ConcertAfisha.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ConcertAfisha.Infrastructure;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    public JwtTokenService(IConfiguration configuration, IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }
    public async Task<(string accessToken, string refreshToken)> GenerateToken(Guid userId,
        string role)
    {
        var jwtSettings = _configuration.GetSection("Jwt");

        var claims = new[]
        {
            new Claim("UserId", userId.ToString()),
            new Claim(ClaimTypes.Role, role)
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpiresMinutes"])),
            signingCredentials: creds
        );
        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        var refreshToken = await _unitOfWork.RefreshTokens.GetByUserIdAsync(userId);
        if (refreshToken == null)
        {
            var newRefreshToken = new RefreshToken(Guid.NewGuid(), userId, GenerateRefreshToken(),
                DateTime.Now.ToUniversalTime().AddDays(double.Parse(jwtSettings["RefreshTokenExpiresDay"])));
            await _unitOfWork.RefreshTokens.AddAsync(newRefreshToken);
            await _unitOfWork.Complete();
            return (accessToken, newRefreshToken.Token);
        }
        if (refreshToken.Expires < DateTime.Now.ToUniversalTime())
        {
            var newRefreshToken = refreshToken;
            newRefreshToken.Token = GenerateRefreshToken();
            newRefreshToken.Expires = DateTime.Now.ToUniversalTime().AddDays(double.Parse(jwtSettings["RefreshTokenExpiresDay"]));
            await _unitOfWork.RefreshTokens.UpdateAsync(newRefreshToken);
            await _unitOfWork.Complete();
            return (accessToken, newRefreshToken.Token);
        }
        return (accessToken, refreshToken.Token);
    }
    public string GenerateRefreshToken()
    {
        var randomBytes = new byte[64];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}