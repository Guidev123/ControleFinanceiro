using ControleFinanceiro.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ControleFinanceiro.API.Configuration
{
    public static class AppConfiguration
    {
        public static void UseConfigureDevEnvironmentConfig(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapSwagger().RequireAuthorization();
        }

        public static void UseSecurityConfig(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
        }

        public static void UseIdentityEndPointsConfig(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGroup("api/identity")
                    .WithTags("Identity")
                    .MapIdentityApi<User>();

                endpoints.MapGroup("api/identity")
                    .WithTags("Identity")
                    .MapPost("/logout", async (SignInManager<User> signInManager) =>
                    {
                        await signInManager.SignOutAsync();
                    });

                endpoints.MapGroup("api/identity")
                    .WithTags("Identity")
                    .MapGet("/roles", (ClaimsPrincipal user) =>
                    {
                        if (user.Identity is null || !user.Identity.IsAuthenticated) return Results.Unauthorized();

                        var identity = (ClaimsIdentity)user.Identity;

                        var roles = identity.FindAll(identity.RoleClaimType).Select(c => new
                        {
                            c.Issuer,
                            c.OriginalIssuer,
                            c.Type,
                            c.Value,
                            c.ValueType
                        });

                        return TypedResults.Json(roles);
                    });
            });
        }
    }
}
