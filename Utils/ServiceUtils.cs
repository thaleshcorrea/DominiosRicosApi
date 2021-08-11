using Microsoft.Extensions.DependencyInjection;
using Teste.Data;
using Teste.Data.Repositories;
using Teste.Data.Repositories.Contracts;
using Teste.Services;
using Teste.Services.Contracts;

namespace Teste.Utils
{
    public static class ServiceUtils
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<INotaFiscalService, NotaFiscalService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<INotaFiscalRepository, NotaFiscalRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}