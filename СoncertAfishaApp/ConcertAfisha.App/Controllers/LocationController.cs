using ConcertAfisha.Application.DTOs.Location;
using ConcertAfisha.Application.Exceptions;
using ConcertAfisha.Application.UseCases.Location;
using Microsoft.AspNetCore.Mvc;

namespace ConcertAfishaApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly CreateLocationUseCase _createLocationUseCase;
    private readonly GetLocationByIdUseCase _getLocationByIdUseCase;
    private readonly UpdateLocationUseCase _updateLocationUseCase;
    private readonly DeleteLocationUseCase _deleteLocationUseCase;
    private readonly GetAllLocationUseCase _getAllLocationUseCase;

    public LocationController(CreateLocationUseCase createLocationUseCase, GetLocationByIdUseCase getLocationByIdUseCase, UpdateLocationUseCase updateLocationUseCase, DeleteLocationUseCase deleteLocationUseCase, GetAllLocationUseCase getAllLocationUseCase)
    {
        _createLocationUseCase = createLocationUseCase;
        _getLocationByIdUseCase = getLocationByIdUseCase;
        _updateLocationUseCase = updateLocationUseCase;
        _deleteLocationUseCase = deleteLocationUseCase;
        _getAllLocationUseCase = getAllLocationUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLocations()
    {
        var locations = await _getAllLocationUseCase.Execute();
        return Ok(locations);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetLocationById(Guid id)
    {
        try
        {
            var location = await _getLocationByIdUseCase.Execute(id);
            return Ok(location);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPut("{id:guid}")]
    // [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> UpdateLocation(Guid id, [FromBody] LocationRequestDto requestDto)
    {
        try
        {
            await _updateLocationUseCase.Execute(id, requestDto);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id:guid}")]
    // [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> DeleteLocation(Guid id)
    {
        try
        {
            await _deleteLocationUseCase.Execute(id);
            return NoContent();
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
    [HttpPost]
    // [Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> AddLocation([FromBody] LocationRequestDto requestDto)
    {
        try
        {
            var id = await _createLocationUseCase.Execute(requestDto);
            return CreatedAtAction(nameof(GetLocationById), new { id }, id);
        }
        catch (DuplicateException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
}