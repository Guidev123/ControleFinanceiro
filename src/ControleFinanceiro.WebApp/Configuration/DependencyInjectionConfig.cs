using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.WebApp.Handlers;
using ControleFinanceiro.WebApp.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace ControleFinanceiro.WebApp.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            // HANDLERS
            services.AddTransient<ICategoryHandler, CategoryHandler>();
            services.AddTransient<ITransactionHandler, TransactionHandler>();
            services.AddTransient<IAccountHandler, AccountHandler>();


            // AUTH
            services.AddScoped<CookieHandler>();
            services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
            services.AddScoped(x => (ICookieAuthenticationStateProvider)x.GetRequiredService<AuthenticationStateProvider>());

            // THEME
            services.AddMudServices();
        }
    }
}
