using Microsoft.Extensions.DependencyInjection;
using Mundo.Business.Interfaces;
using Mundo.Business.Notifications;
using Mundo.Data;
using Mundo.Data.Repositories;

namespace Mundo.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MundoContext>();

            services.AddScoped<INotificator, Notificator>();

            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPetRepository, PetRepository>();

            return services;
        }
    }
}
