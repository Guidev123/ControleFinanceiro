using ControleFinanceiro.API.Notifications;

namespace ControleFinanceiro.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void ResolveDependencies(this IServiceCollection services) 
        {
            services.AddScoped<INotificator, Notificator>();
        }
    }
}
