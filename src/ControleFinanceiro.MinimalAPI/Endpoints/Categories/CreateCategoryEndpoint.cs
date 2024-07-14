using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models;
using ControleFinanceiro.Core.Responses;
using ControleFinanceiro.MinimalAPI.Application;
using System.Security.Claims;

namespace ControleFinanceiro.MinimalAPI.Endpoints.Categories
{
    public class CreateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
                .Produces<Response<Category?>>();

        private static async Task<IResult> HandleAsync(
                                ClaimsPrincipal user,
                                ICategoryHandler handler,
                                CreateCategoryCommand command)
        {
            command.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.CreateAsync(command);
            return result.IsSuccess
                ? TypedResults.Created($"/{result.Data?.Id}", result)
                : TypedResults.BadRequest(result.Data);
        }
    }
}
