using ControleFinanceiro.API.Handlers;
using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Commands.Transactions;
using ControleFinanceiro.Core.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/transactions")]
    [Authorize]
    public class TransactionsController : MainController
    {
        private readonly ITransactionHandler _transactionHandler;
        private readonly ClaimsPrincipal _user;

        public TransactionsController(ITransactionHandler transactionHandler,
                                      ClaimsPrincipal user)
        {
            _transactionHandler = transactionHandler;
            _user = user;
        }

        [HttpPost]
        public async Task<IResult> CreateTransaction(CreateTransactionCommand command)
        {
            command.UserId = _user.Identity?.Name ?? string.Empty;

            var result = await _transactionHandler.CreateAsync(command);

            if (!result.IsSuccess) return Results.BadRequest(result);

            return Results.Ok(result);
        }

        [HttpPut("{id:long}")]
        public async Task<IResult> UpdateTransaction(UpdateTransactionCommand command, long id)
        {
            command.Id = id;
            command.UserId = _user.Identity?.Name ?? string.Empty;

            var result = await _transactionHandler.UpdateAsync(command);
            if (!result.IsSuccess) return Results.BadRequest(result);

            return Results.Ok(result);
        }

        [HttpDelete("{id:long}")]
        public async Task<IResult> DeleteTransaction(long id)
        {
            var command = new DeleteTransactionCommand
            {
                Id = id,
                UserId = _user.Identity?.Name ?? string.Empty
            };

            var result = await _transactionHandler.DeleteAsync(command);

            if (!result.IsSuccess) return Results.BadRequest(result);
            return Results.Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IResult> GetTransactionById(long id)
        {
            var command = new GetTransactionByIdCommand
            {
                Id = id,
                UserId = _user.Identity?.Name ?? string.Empty
            };
            var result = await _transactionHandler.GetByIdAsync(command);
            if (!result.IsSuccess) return Results.BadRequest(result);

            return Results.Ok(result);
        }

        [HttpGet]
        public async Task<IResult> GetByPeriod([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25, [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            var category = new GetTransactionByPeriodCommand
            {
                UserId = _user.Identity?.Name ?? string.Empty,
                PageNumber = pageNumber,
                PageSize = pageSize,
                StartDate = startDate,
                EndDate = endDate
            };

            var result = await _transactionHandler.GetByPeriodAsync(category);
            if (!result.IsSuccess) return Results.BadRequest(result);

            return Results.Ok(result);
        }
    }
}
