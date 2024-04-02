using Application.Services;
using Domain.Ports;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>();
            return service;
        }
    }
}
