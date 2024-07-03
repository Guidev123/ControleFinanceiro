using ControleFinanceiro.API.Handlers;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ControleFinanceiro.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ResolveDependencies(this IServiceCollection services, IConfiguration configuration) 
        {

            // HANDLER

            services.AddTransient<ICategoryHandler, CategoryHandler>();
            services.AddTransient<ITransactionHandler, TransactionHandler>();

            // USER
            services.AddScoped<ClaimsPrincipal>();

        }
    }
}
