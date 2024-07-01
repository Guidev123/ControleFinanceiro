using ControleFinanceiro.API.Handlers;
using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Commands.Transactions;
using ControleFinanceiro.Core.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Route("api/transactions")]
    public class TransactionsController : MainController
    {
        private readonly ITransactionHandler _transactionHandler;

        public TransactionsController(ITransactionHandler transactionHandler)
        {
            _transactionHandler = transactionHandler;
        }

        [HttpPost]
        public async Task<IResult> CreateTransaction(CreateTransactionCommand command)
        {
            command.UserId = "string";

            var result = await _transactionHandler.CreateAsync(command);

            if (!result.IsSuccess) return Results.BadRequest(result);

            return Results.Ok(result);
        }

        [HttpPut("{id:long}")]
        public async Task<IResult> UpdateTransaction(UpdateTransactionCommand command, long id)
        {
            command.Id = id;
            command.UserId = "string";

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
                UserId = "string"
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
                UserId = "string"
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
                UserId = "string",
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
