using Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        Configure(app);


        var serviceProvider = ConfigureServices();

        var s3Service = serviceProvider.GetRequiredService<S3ApplicationService>();

        string queueUrl = "url_da_fila_sqs";
        await s3Service.ProcessarMensagemSqsAsync(queueUrl);

        app.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<S3ApplicationService>();

        return services.BuildServiceProvider();
    }

    private static void Configure(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
