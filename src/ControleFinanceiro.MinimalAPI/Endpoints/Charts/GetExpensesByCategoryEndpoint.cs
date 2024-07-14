using ControleFinanceiro.Core.Commands.Charts;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models.Charts;
using ControleFinanceiro.Core.Responses;
using ControleFinanceiro.MinimalAPI.Application;
using System.Security.Claims;

namespace ControleFinanceiro.MinimalAPI.Endpoints.Charts
{
    public class GetExpensesByCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/expenses", HandleAsync)
            .Produces<Response<List<ExpensesByCategory>?>>();
     

        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, IChartHandler handler)
        {
            var command = new GetExpensesByCategoryCommand
            {
                UserId = user.Identity?.Name ?? string.Empty
            };

            var result = await handler.GetExpensesByCategoryChartAsync(command);

            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
