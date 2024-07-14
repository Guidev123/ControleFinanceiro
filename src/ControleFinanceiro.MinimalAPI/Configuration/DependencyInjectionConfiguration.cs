using ControleFinanceiro.API.Handlers;
using ControleFinanceiro.Core.Commands.Account;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models.Account;
using ControleFinanceiro.Data;
using ControleFinanceiro.MinimalAPI.Handlers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ControleFinanceiro.MinimalAPI.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ResolveDependencies(this IServiceCollection services, IConfiguration configuration) 
        {

            // HANDLER
            services.AddTransient<ICategoryHandler, CategoryHandler>();
            services.AddTransient<ITransactionHandler, TransactionHandler>();
            services.AddTransient<IChartHandler, ChartHandler>();

        }
    }
}
