using AutoMapper;
using ConcertAfisha.Application.DTOs.User;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Core.Abstractions.Auth;
using ConcertAfisha.Core.Abstractions.Repositories;

namespace ConcertAfisha.Application.UseCases.User;

public class UpdateUserUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;

    public UpdateUserUseCase(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<UsersResponseDto> Execute(Guid id, UserRegisterRequestDto request)
    {
        var existedUsers = await _unitOfWork.Users.GetByIdAsync(id);
        var password = request.Password == "" ? existedUsers.Password : _passwordHasher.HashPassword(request.Password);
        if (existedUsers == null)
            throw new NotFoundException("user not found");
        var updatedUser = _mapper.Map(request, existedUsers);
        updatedUser.Password = password;
        await _unitOfWork.Users.UpdateAsync(updatedUser);
        await _unitOfWork.Complete();
        return _mapper.Map<UsersResponseDto>(existedUsers);
    }
}