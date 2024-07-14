using ControleFinanceiro.Data.Models;
using ControleFinanceiro.MinimalAPI.Application;
using Microsoft.AspNetCore.Identity;

namespace ControleFinanceiro.MinimalAPI.Endpoints.Identity
{
    public class LogoutEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app
                .MapPost("/logout", HandleAsync)
                .RequireAuthorization();

        private static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
        {
            await signInManager.SignOutAsync();
            return Results.Ok();
        }
    }
}
