namespace EmailCommunication.Domain.Services;

public interface IEmailService
{
    Task SendIncompleteRegistrationEmailAsync(string email, string name);
    Task SendBirthdayEmailAsync(string email, string name);
}
