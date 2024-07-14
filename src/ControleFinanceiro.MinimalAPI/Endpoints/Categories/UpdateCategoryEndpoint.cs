using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models;
using ControleFinanceiro.Core.Responses;
using ControleFinanceiro.MinimalAPI.Application;
using System.Security.Claims;

namespace ControleFinanceiro.MinimalAPI.Endpoints.Categories
{
    public class UpdateCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
                .Produces<Response<Category?>>();

        private static async Task<IResult> HandleAsync(
            ClaimsPrincipal user,
            ICategoryHandler handler,
            UpdateCategoryCommand command,
            long id)
        {
            command.UserId = user.Identity?.Name ?? string.Empty;
            command.Id = id;

            var result = await handler.UpdateAsync(command);
            return result.IsSuccess
                ? TypedResults.Ok(result)
                : TypedResults.BadRequest(result);
        }
    }
}
