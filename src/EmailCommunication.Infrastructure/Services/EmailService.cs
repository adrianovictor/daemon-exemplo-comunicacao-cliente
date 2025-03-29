using System.Net;
using System.Net.Mail;
using EmailCommunication.Domain.Services;
using Microsoft.Extensions.Configuration;

namespace EmailCommunication.Infrastructure.Services;

public class EmailService(IConfiguration configuration) : IEmailService
{
    private readonly IConfiguration _configuration = configuration;

    public async Task SendBirthdayEmailAsync(string email, string name)
    {
        var subject = "Feliz Aniversário!";
        var body = $"Olá {name}, queremos desejar um feliz aniversário! " +
                    "Como presente, oferecemos um cupom especial para você.";
        
        await SendEmailAsync(email, subject, body);
    }

    public async Task SendIncompleteRegistrationEmailAsync(string email, string name)
    {
        var subject = "Complete seu cadastro";
        var body = $"Olá {name}, percebemos que você não completou seu cadastro. " +
                    "Por favor, acesse nosso site para finalizar o processo.";
        
        await SendEmailAsync(email, subject, body);
    }

    private async Task SendEmailAsync(string to, string subject, string body)
    {
        var (_smtpServer, _port, _username, _password, _fromAddress) = GetConfiguration();

        using var client = new SmtpClient(_smtpServer, _port)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(_username, _password)
        };
        
        using var message = new MailMessage(_fromAddress, to, subject, body)
        {
            IsBodyHtml = true
        };
        
        await client.SendMailAsync(message);
    }

    private (string smtpServer, int portServer, string username, string password, string fromAddress) GetConfiguration()
    {
        var emailSettings = _configuration.GetSection("EmailSettings");

        var smtp = emailSettings["SmtpServer"]!;
        var port = int.Parse(emailSettings["Port"]!);
        var username = emailSettings["Username"]!;
        var password = emailSettings["Password"]!;
        var from = emailSettings["FromAddress"]!;

        return (smtp, port, username, password, from);
    }
}
