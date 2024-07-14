using ControleFinanceiro.Core.Models.Account;
using ControleFinanceiro.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using User = ControleFinanceiro.Data.Models.User;

namespace ControleFinanceiro.MinimalAPI.Configuration
{
    public static class AppConfiguration
    {
        public static void ConfigureDevEnvironment(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger().RequireAuthorization();
        }
        public static void UseSecurity(this WebApplication app)
        {
            app.UseCors("Total");

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
