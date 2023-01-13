using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace Nebula.Demo;

public class Program
{
    public static async Task Main(string[] args)
    {
        var hostBuilder = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddHostedService<PqmBackgroundService>();
                services.AddApplication<PqmModule>(optionsAction =>
                {
                    optionsAction.ApplicationName = "PQM";
                });
            }).UseAutofac();
        var host = hostBuilder.Build();
        var application = host.Services.GetRequiredService<IAbpApplicationWithExternalServiceProvider>();

        await application.InitializeAsync(host.Services);

        await host.RunAsync();

        Console.Read();
    }
}