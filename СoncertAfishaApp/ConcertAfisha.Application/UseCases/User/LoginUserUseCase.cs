using AutoMapper;
using ConcertAfisha.Application.DTOs.User;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Auth;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.User;

public class LoginUserUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public LoginUserUseCase(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task<UsersResponseDto> Execute(UserLoginRequestDto request)
    {
        Core.Models.User foundedUser = null;
        if (request.Email != "")
        {
            foundedUser = await _unitOfWork.Users.GetByEmailAsync(request.Email);
        }
        if (request.Phone != "" && foundedUser == null)
        {
            foundedUser = await _unitOfWork.Users.GetByPhoneAsync(request.Phone);
        }
        if (foundedUser == null)
        {
            throw new InvalidLoginException("No email or phone provided");
        }
        
        if (foundedUser == null || !_passwordHasher.VerifyHashedPassword(foundedUser.Password, request.Password))
        {
            throw new InvalidLoginException("Invalid username or password");
        }

        return _mapper.Map<UsersResponseDto>(foundedUser);
    }
}