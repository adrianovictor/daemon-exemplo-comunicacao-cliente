using EmailCommunication.Domain.Repositories;
using EmailCommunication.Domain.Services;
using Quartz;

namespace EmailCommunication.Daemon.Jobs;

[DisallowConcurrentExecution]
public class BirthdayEmailJob(ICustomerRepository customerRepository, IEmailService emailService, ILogger<BirthdayEmailJob> logger) : IJob
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IEmailService _emailService = emailService;
    private readonly ILogger<BirthdayEmailJob> _logger = logger;

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("Iniciando job de envio de e-mails de aniversário");
        
        var users = await _customerRepository.GetCustomersBirthdayTodayAsync();
        
        foreach (var user in users)
        {
            try
            {
                //await _emailService.SendBirthdayEmailAsync(user.Email, user.FirstName);
                _logger.LogInformation($"E-mail de aniversário enviado para {user.Email}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao enviar e-mail de aniversário para {user.Email}");
            }
        }
        
        _logger.LogInformation("Job de envio de e-mails de aniversário finalizado");
    }
}
