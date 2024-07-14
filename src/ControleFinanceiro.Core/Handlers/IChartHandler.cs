using ControleFinanceiro.Core.Commands.Charts;
using ControleFinanceiro.Core.Models.Charts;
using ControleFinanceiro.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Handlers
{
    public interface IChartHandler
    {
        Task<Response<List<IncomesAndExpenses>?>> GetIncomesAndExpensesChartAsync(GetIncomesAndExpensesCommand command);
        Task<Response<List<IncomesByCategory>?>> GetIncomesByCategoryChartAsync(GetIncomesByCategoryCommand command);
        Task<Response<List<ExpensesByCategory>?>> GetExpensesByCategoryChartAsync(GetExpensesByCategoryCommand command);
        Task<Response<FinancialSummary?>> GetFinancialSummaryChartAsync(GetFinancialSummaryCommand command);
    }
}
