using Azure.Core;
using ControleFinanceiro.Core.Commands.Charts;
using ControleFinanceiro.Core.Enums;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models.Charts;
using ControleFinanceiro.Core.Responses;
using ControleFinanceiro.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.MinimalAPI.Handlers
{
    public class ChartHandler(AppDbContext _context) : IChartHandler
    {
        public async Task<Response<List<IncomesAndExpenses>?>> GetIncomesAndExpensesChartAsync(GetIncomesAndExpensesCommand command)
        {
            try
            {
                var data = await _context
                    .IncomesAndExpenses
                    .AsNoTracking()
                    .Where(x => x.UserId == command.UserId)
                    .OrderByDescending(x => x.Year)
                    .ThenBy(x => x.Month)
                    .ToListAsync();

                return new Response<List<IncomesAndExpenses>?>(data);
            }
            catch
            {
                return new Response<List<IncomesAndExpenses>?>(null, 500, "Não foi possível obter as entradas e saídas");
            }
        }
        public async Task<Response<List<IncomesByCategory>?>> GetIncomesByCategoryChartAsync(GetIncomesByCategoryCommand command)
        {
            try
            {
                var data = await _context.IncomesByCategories.AsNoTracking()
                    .Where(x => x.UserId == command.UserId).OrderByDescending(x => x.Year).ThenBy(x => x.Category).ToListAsync();

                return new Response<List<IncomesByCategory>?>(data);
            }
            catch
            {
                return new Response<List<IncomesByCategory>?>(null, 500, "Não foi possível obter as entradas por categoria");
            }
        }
        public async Task<Response<List<ExpensesByCategory>?>> GetExpensesByCategoryChartAsync(GetExpensesByCategoryCommand command)
        {
            try
            {
                var data = await _context.ExpensesByCategories.AsNoTracking().Where(x => x.UserId == command.UserId).OrderByDescending(x => x.Year)
                    .ThenBy(x => x.Category)
                    .ToListAsync();

                return new Response<List<ExpensesByCategory>?>(data);
            }
            catch
            {
                return new Response<List<ExpensesByCategory>?>(null, 500, "Não foi possível obter as entradas por categoria");
            }
        }

        public async Task<Response<FinancialSummary?>> GetFinancialSummaryChartAsync(GetFinancialSummaryCommand command)
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            try
            {
                var data = await _context
                    .Transactions
                    .AsNoTracking()
                    .Where(
                        x => x.UserId == command.UserId
                             && x.PaidOrReceivedAt >= startDate
                             && x.PaidOrReceivedAt <= DateTime.Now
                    )
                    .GroupBy(x => 1)
                    .Select(x => new FinancialSummary(
                        command.UserId,
                        x.Where(ty => ty.TransactionType == ETransactionType.Deposit).Sum(t => t.Amount),
                        x.Where(ty => ty.TransactionType == ETransactionType.Withdraw).Sum(t => t.Amount))
                    )
                    .FirstOrDefaultAsync();

                return new Response<FinancialSummary?>(data);
            }
            catch
            {
                return new Response<FinancialSummary?>(null, 500,
                    "Não foi possível obter o resultado financeiro");
            }
        }
    }
}
