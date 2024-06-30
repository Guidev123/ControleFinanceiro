using ControleFinanceiro.API.Handlers;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ResolveDependencies(this IServiceCollection services, IConfiguration configuration) 
        {

            // HANDLER
            services.AddTransient<ICategoryHandler, CategoryHandler>();

        }
    }
}
