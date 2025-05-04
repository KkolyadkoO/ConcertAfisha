using ConcertAfisha.Application.UseCases.Email;
using ConcertAfisha.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConcertAfishaApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NewsletterController: ControllerBase
{
    private readonly SendEmailUseCase _emailService;

    public NewsletterController(SendEmailUseCase emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("subscribe")]
    public async Task<IActionResult> Subscribe([FromBody] SubscribeRequest request)
    {
        try
        {
            await _emailService.SendEmailAsync(new EmailRequest
            {
                ToEmail = request.Email,
                Subject = "Подтверждение подписки",
                Body = $"<h1>Спасибо за подписку!</h1><p>Вы успешно подписались на нашу концертную рассылку.</p>"
            });

            return Ok(new { success = true });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}