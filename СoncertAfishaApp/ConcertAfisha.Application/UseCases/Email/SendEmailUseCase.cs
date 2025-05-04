using System.Net;
using System.Net.Mail;
using ConcertAfisha.Core.Models;
using Microsoft.Extensions.Configuration;

namespace ConcertAfisha.Application.UseCases.Email;

public class SendEmailUseCase
{
    private readonly IConfiguration _config;

    public SendEmailUseCase(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(EmailRequest request)
    {
        var smtp = _config.GetSection("SmtpSettings");
        
        var client = new SmtpClient(smtp["Server"])
        {
            Port = int.Parse(smtp["Port"]),
            Credentials = new NetworkCredential(smtp["Username"], smtp["Password"]),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(smtp["FromEmail"], smtp["FromName"]),
            Subject = request.Subject,
            Body = request.Body,
            IsBodyHtml = true,
        };
        
        mailMessage.To.Add(request.ToEmail);

        await client.SendMailAsync(mailMessage);
    }
}