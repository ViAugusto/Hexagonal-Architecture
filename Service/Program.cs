using Application.Services;
using AWS;
using Domain.Ports;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service;

class Program
{
    static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        host.Run();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                services.AddHostedService<Worker>();

                services.AddSingleton<S3ApplicationService>();
                services.AddSingleton<IS3Service, S3Adapter>();
                services.AddSingleton<ISqsService, SqsAdapter>();
            });

}