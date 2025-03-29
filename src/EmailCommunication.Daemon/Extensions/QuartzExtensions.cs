using Quartz;

namespace EmailCommunication.Daemon.Extensions;

public static class QuartzExtensions
{
    /// <summary>
    /// Registra um job no Quartz com configurações baseadas em uma seção do appsettings.json
    /// </summary>
    /// <typeparam name="T">Tipo do job a ser registrado</typeparam>
    /// <param name="configurator">O configurador do Quartz</param>
    /// <param name="configuration">O objeto de configuração</param>
    /// <param name="sectionPath">Caminho da seção no appsettings.json</param>
    /// <returns>O configurador do Quartz para encadeamento de métodos</returns>
    public static IServiceCollectionQuartzConfigurator RegisterJobFromConfiguration<T>(
        this IServiceCollectionQuartzConfigurator configurator,
        IConfiguration configuration,
        string sectionPath) where T : class, IJob
    {
        // Obtém a seção de configuração completa
        var section = configuration.GetSection(sectionPath);

        if (section == null || !section.Exists())
        {
            throw new ArgumentException($"Seção de configuração '{sectionPath}' não encontrada");
        }

        // Obtém os valores específicos
        string jobName = section["Name"] ?? throw new ArgumentException($"'{sectionPath}:Name' não encontrado na configuração");
        string triggerName = section["Trigger"] ?? throw new ArgumentException($"'{sectionPath}:Trigger' não encontrado na configuração");
        string cronExpression = section["Cron"] ?? throw new ArgumentException($"'{sectionPath}:Cron' não encontrado na configuração");

        // Registra o job
        configurator.AddJob<T>(opts => opts.WithIdentity(jobName));

        // Registra o trigger com cronExpression
        configurator.AddTrigger(opts => opts
            .ForJob(jobName)
            .WithIdentity(triggerName)
            .WithCronSchedule(cronExpression));

        return configurator;
    }
}
