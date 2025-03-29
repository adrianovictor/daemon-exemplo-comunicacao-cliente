using EmailCommunication.Daemon;
using EmailCommunication.Daemon.Extensions;
using EmailCommunication.Daemon.Jobs;
using EmailCommunication.Domain.Repositories;
using EmailCommunication.Domain.Services;
using EmailCommunication.Infrastructure.DataContext;
using EmailCommunication.Infrastructure.Repositories;
using EmailCommunication.Infrastructure.Services;
using Quartz;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var host = Host.CreateDefaultBuilder(args)
.ConfigureServices((hostContext, services) => {
    services.AddQuartz(q => 
    {
        // Registro do job para cadastros incompletos
        q.RegisterJobFromConfiguration<IncompleteRegistrationJob>(hostContext.Configuration, $"Jobs:{nameof(IncompleteRegistrationJob)}");

        // Registro do job para aniversários
        q.RegisterJobFromConfiguration<BirthdayEmailJob>(hostContext.Configuration, $"Jobs:{nameof(BirthdayEmailJob)}");
    });

    services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

    services.AddSingleton<IDbContext>(new DbContext(builder.Configuration.GetConnectionString("DefaultConnection")!));
    services.AddScoped<ICustomerRepository, CustomerRepository>();
    services.AddScoped<IEmailService, EmailService>();
})
.Build();

host.Run();
