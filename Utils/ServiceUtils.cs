using Microsoft.Extensions.DependencyInjection;
using Teste.Data;
using Teste.Repositories.ClienteRepositories;
using Teste.Services.ClienteServices;

namespace Teste.Utils
{
    public static class ServiceUtils
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}