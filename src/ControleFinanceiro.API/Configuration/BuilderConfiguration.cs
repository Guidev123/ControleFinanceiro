using ControleFinanceiro.API.Extensions;
using ControleFinanceiro.Data;
using ControleFinanceiro.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ControleFinanceiro.API.Configuration
{
    public static class BuilderConfiguration
    {
        public static void AddDbContextsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                    options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityCore<User>()
                .AddRoles<IdentityRole<long>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddApiEndpoints();

            AppSettings.BackendUrl = configuration.GetValue<string>("BackendUrl") ?? string.Empty;
            AppSettings.FrontendUrl = configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
        }

        public static void AddDocumentationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(n => n.FullName);
            });
        }

        public static void AddSecurityConfig(this IServiceCollection services)
        {
            services.AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddIdentityCookies();

            services.AddAuthorization();
        }

        public static void AddCorsConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
            options => options.AddPolicy(
                CorsPolicy.CorsPolicyName,
                policy => policy
                    .WithOrigins([
                        AppSettings.BackendUrl,
                        AppSettings.FrontendUrl
                    ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            ));
        }
    }
}
