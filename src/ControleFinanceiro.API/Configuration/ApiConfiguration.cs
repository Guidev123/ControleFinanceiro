using ControleFinanceiro.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.API.Configuration
{
    public static class ApiConfiguration
    {
        public static void CustomConfigurationAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        } 
    }
}
