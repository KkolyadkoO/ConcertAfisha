using ConcertAfisha.Core.Models;
using ConcertAfisha.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ConcertAfishaApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = Enum.GetValues(typeof(Category))
            .Cast<Category>()
            .Select(c => new 
            {
                Id = (int)c,
                Name = c.ToString(),
                DisplayName = c.GetDescription()  
            });

        return Ok(categories);
    }
}