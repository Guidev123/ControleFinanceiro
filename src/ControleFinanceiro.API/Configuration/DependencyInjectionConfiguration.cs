using ControleFinanceiro.API.Notifications;
using ControleFinanceiro.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ResolveDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<INotificator, Notificator>();

            // DB CONTEXT CONFIG
            var connectionStr = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionStr));

        }
    }
}
