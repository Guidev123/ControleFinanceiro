using ControleFinanceiro.Core.Commands.Charts;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models.Charts;
using ControleFinanceiro.Core.Responses;
using System.Net.Http.Json;

namespace ControleFinanceiro.WebApp.Handlers
{
    public class ChartHandler(IHttpClientFactory _clientFactory) : IChartHandler
    {
        private readonly HttpClient _client = _clientFactory.CreateClient(WebConfiguration.HTTP_CLIENT_NAME);
        public async Task<Response<List<IncomesAndExpenses>?>> GetIncomesAndExpensesChartAsync(GetIncomesAndExpensesCommand command)
        {
            return await _client.GetFromJsonAsync<Response<List<IncomesAndExpenses>?>>($"api/charts/incomes-expenses") ??
                new Response<List<IncomesAndExpenses>?>(null, 400, "Nao foi possivel obter os dados");
        }
        public async Task<Response<List<ExpensesByCategory>?>> GetExpensesByCategoryChartAsync(GetExpensesByCategoryCommand command)
        {
            return await _client.GetFromJsonAsync<Response<List<ExpensesByCategory>?>>($"api/charts/expenses") ??
                new Response<List<ExpensesByCategory>?>(null, 400, "Nao foi possivel obter os dados");
        }

        public async Task<Response<FinancialSummary?>> GetFinancialSummaryChartAsync(GetFinancialSummaryCommand command)
        {
            return await _client.GetFromJsonAsync<Response<FinancialSummary?>>($"api/charts/summary") ??
                new Response<FinancialSummary?>(null, 400, "Nao foi possivel obter os dados");
        }


        public async Task<Response<List<IncomesByCategory>?>> GetIncomesByCategoryChartAsync(GetIncomesByCategoryCommand command)
        {
            return await _client.GetFromJsonAsync<Response<List<IncomesByCategory>?>>($"api/charts/incomes") ??
                new Response<List<IncomesByCategory>?>(null, 400, "Nao foi possivel obter os dados");
        }
    }
}
