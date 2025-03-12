using AutoMapper;
using ConcertAfisha.Application.DTOs.User;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Auth;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.User;

public class RegisterUserUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMapper _mapper;

    public RegisterUserUseCase(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _mapper = mapper;
    }

    public async Task Execute(UserRegisterRequestDto request)
    {
        var existingUserEmail = await _unitOfWork.Users.GetByEmailAsync(request.UserEmail);
        if (existingUserEmail != null)
        {
            throw new DuplicateException("A user with this email already exists");
        }
        var existingUserPhone = await _unitOfWork.Users.GetByPhoneAsync(request.Phone);
        if (existingUserPhone != null)
        {
            throw new DuplicateException("A user with this phone already exists");
        }

        var user = _mapper.Map<Core.Models.User>(request);
        user.Password = _passwordHasher.HashPassword(request.Password);

        await _unitOfWork.Users.AddAsync(user);
        await _unitOfWork.Complete();
    }
}