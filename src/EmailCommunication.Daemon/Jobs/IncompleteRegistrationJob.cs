using EmailCommunication.Domain.Repositories;
using EmailCommunication.Domain.Services;
using Quartz;

namespace EmailCommunication.Daemon.Jobs;

[DisallowConcurrentExecution]
public class IncompleteRegistrationJob(ICustomerRepository customerRepository, IEmailService emailService, ILogger<IncompleteRegistrationJob> logger) : IJob
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IEmailService _emailService = emailService;
    private readonly ILogger<IncompleteRegistrationJob> _logger = logger;

    public async Task Execute(IJobExecutionContext context)
    {
        _logger.LogInformation("Iniciando job de envio de e-mails para cadastros incompletos");
        
        var users = await _customerRepository.GetCustomersWithIncompleteRegistrationAsync();
        
        foreach (var user in users)
        {
            try
            {
                //await _emailService.SendIncompleteRegistrationEmailAsync(user.Email, user.FirstName);
                _logger.LogInformation($"E-mail enviado para {user.Email} sobre cadastro incompleto");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao enviar e-mail para {user.Email}");
            }
        }
        
        _logger.LogInformation("Job de envio de e-mails para cadastros incompletos finalizado");
    }
}
