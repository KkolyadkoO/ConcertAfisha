using ConcertAfisha.Application.DTOs.Concert;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Application.UseCases.Concert;
using Microsoft.AspNetCore.Mvc;

namespace ConcertAfishaApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConcertController : ControllerBase
{
    private readonly CreateConcertUseCase _createConcertUseCase;
    private readonly GetConcertsByFiltersUseCase _getConcertsByFiltersUseCase;
    private readonly GetConcertByIdUseCase _getConcertByIdUseCase;
    private readonly UpdateConcertUseCase _updateConcertUseCase;
    private readonly DeleteConcertUseCase _deleteConcertUseCase;

    public ConcertController(CreateConcertUseCase createConcertUseCase,
        GetConcertsByFiltersUseCase getConcertsByFiltersUseCase, GetConcertByIdUseCase getConcertByIdUseCase,
        UpdateConcertUseCase updateConcertUseCase, DeleteConcertUseCase deleteConcertUseCase)
    {
        _createConcertUseCase = createConcertUseCase;
        _getConcertsByFiltersUseCase = getConcertsByFiltersUseCase;
        _getConcertByIdUseCase = getConcertByIdUseCase;
        _updateConcertUseCase = updateConcertUseCase;
        _deleteConcertUseCase = deleteConcertUseCase;
    }

    [HttpGet("filter/")]
    public async Task<ActionResult> GetFiterConcerts([FromQuery] ConcertFilterRequestDto filterRequest)
    {
        var (concerts, countOfConcerts) = await _getConcertsByFiltersUseCase.Execute(filterRequest);

        return Ok(new
        {
            Concerts = concerts,
            TotalConcertsCount = countOfConcerts,
        });
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ConcertsResponseDto>> GetConcertById(Guid id)
    {
        var foundedConcert = await _getConcertByIdUseCase.Execute(id);

        return Ok(new
        {
            Concert = foundedConcert,
        });
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateConcert([FromForm] ConcertRequestDto request, IFormFile imageFile)
    {
        try
        {
            var id = await _createConcertUseCase.Execute(request, imageFile);
            return Ok(new { Id = id });
        }
        catch (ApplicationException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
    
    [HttpPut("{id:guid}")]
    // [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<Guid>> UpdateConcert(Guid id, [FromForm] ConcertRequestDto request,
        IFormFile? imageFile)
    {
        try
        {
            await _updateConcertUseCase.Execute(id, request, imageFile);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
        catch (ApplicationException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
    
    [HttpDelete("{id:guid}")]
    // [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<Guid>> DeleteConcert(Guid id)
    {
        try
        {
            await _deleteConcertUseCase.Execute(id);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }
}