using ConcertAfisha.Application.DTOs.Member;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Application.UseCases.Member;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConcertAfishaApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController : Controller
{
    private readonly AddMemberUseCase _addMemberUseCase;
    private readonly DeleteMemberByConcertIdAndUserIdUseCase _deleteMemberByConcertIdAndUserIdUseCase;
    private readonly DeleteMemberUseCase _deleteMemberUseCase;
    private readonly GetAllMembersByConcertIdUseCase _getAllMembersByConcertIdUseCase;
    private readonly GetAllMembersByUserIdUseCase _getAllMembersByUserIdUseCase;
    private readonly GetMemberByIdUseCase _getMemberByIdUseCase;

    public MemberController(AddMemberUseCase addMemberUseCase, DeleteMemberByConcertIdAndUserIdUseCase deleteMemberByConcertIdAndUserIdUseCase, DeleteMemberUseCase deleteMemberUseCase, GetAllMembersByConcertIdUseCase getAllMembersByConcertIdUseCase, GetAllMembersByUserIdUseCase getAllMembersByUserIdUseCase, GetMemberByIdUseCase getMemberByIdUseCase)
    {
        _addMemberUseCase = addMemberUseCase;
        _deleteMemberByConcertIdAndUserIdUseCase = deleteMemberByConcertIdAndUserIdUseCase;
        _deleteMemberUseCase = deleteMemberUseCase;
        _getAllMembersByConcertIdUseCase = getAllMembersByConcertIdUseCase;
        _getAllMembersByUserIdUseCase = getAllMembersByUserIdUseCase;
        _getMemberByIdUseCase = getMemberByIdUseCase;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var member = await _getMemberByIdUseCase.Execute(id);
            return Ok(member);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("concert/{concertId}")]
    public async Task<IActionResult> GetByConcertId(Guid concertId)
    {
        var members = await _getAllMembersByConcertIdUseCase.Execute(concertId);
        return Ok(members);
    }
    
    [HttpGet("user/{userId}")]
    [Authorize]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        var members = await _getAllMembersByUserIdUseCase.Execute(userId);
        return Ok(members);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] MemberRequestDto request)
    {
        var newMemberId = await _addMemberUseCase.Execute(request);
        return CreatedAtAction(nameof(GetById), new { id = newMemberId }, new { id = newMemberId });
    }
    
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _deleteMemberUseCase.Execute(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("concert/{concertId}/user/{userId}")]
    [Authorize]
    public async Task<IActionResult> DeleteByEventIdAndUserId(Guid concertId, Guid userId)
    {
        try
        {
            await _deleteMemberByConcertIdAndUserIdUseCase.Execute(concertId, userId);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}