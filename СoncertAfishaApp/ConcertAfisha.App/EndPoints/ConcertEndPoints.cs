using ConcertAfisha.Application.DTOs.Concert;
using ConcertAfisha.Application.UseCases.Concert;
using Microsoft.AspNetCore.Mvc;

namespace ConcertAfishaApp.EndPoints;

[ApiController]
[Route("api/[controller]")]
public class ConcertEndPoints : ControllerBase
{
    private readonly CreateConcertUseCase _createConcertUseCase;
    private readonly GetConcertsByFiltersUseCase _getConcertsByFiltersUseCase;

    public ConcertEndPoints(CreateConcertUseCase createConcertUseCase, GetConcertsByFiltersUseCase getConcertsByFiltersUseCase)
    {
        _createConcertUseCase = createConcertUseCase;
        _getConcertsByFiltersUseCase = getConcertsByFiltersUseCase;
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

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateConcert([FromForm] ConcertRequestDto request, IFormFile imageFile)
    {
        try
        {
            var id = await _createConcertUseCase.Execute(request, imageFile);
            return Ok(new {Id = id});
        }
        catch (ApplicationException e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
}