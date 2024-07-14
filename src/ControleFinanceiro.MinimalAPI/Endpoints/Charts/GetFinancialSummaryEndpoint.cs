using ControleFinanceiro.Core.Commands.Charts;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models.Charts;
using ControleFinanceiro.Core.Responses;
using ControleFinanceiro.MinimalAPI.Application;
using System.Security.Claims;

namespace ControleFinanceiro.MinimalAPI.Endpoints.Charts
{
    public class GetFinancialSummaryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app) => app.MapGet("/summary", HandleAsync)
            .Produces<Response<FinancialSummary>>();

        private static async Task<IResult> HandleAsync(ClaimsPrincipal user, IChartHandler handler)
        {
            var command = new GetFinancialSummaryCommand
            {
                UserId = user.Identity?.Name ?? string.Empty
            };
            command.UserId = user.Identity?.Name ?? string.Empty;
            var result = await handler.GetFinancialSummaryChartAsync(command);

            return result.IsSuccess ? TypedResults.Ok(result) : TypedResults.BadRequest(result);
        }
    }
}
