using Application.Services;
using AWS;
using Domain.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services)
        {
            services.AddTransient<IS3Service, S3Adapter>();
            services.AddTransient<ISqsService, SqsAdapter>();

            return services;
        }
    }
}
