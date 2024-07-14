using ControleFinanceiro.Core.Commands.Charts;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models.Charts;
using ControleFinanceiro.Core.Responses;
using ControleFinanceiro.MinimalAPI.Application;
using System.Security.Claims;

namespace ControleFinanceiro.MinimalAPI.Endpoints.Charts
{
    public class GetIncomesAndExpensesEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/incomes-expenses", HandleAsync)
            .Produces<Response<List<IncomesAndExpenses>>?>();

        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, IChartHandler handler)
        {
            var command = new GetIncomesAndExpensesCommand
            {
                UserId = user.Identity?.Name ?? string.Empty
            };
            var result = await handler.GetIncomesAndExpensesChartAsync(command);

            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
