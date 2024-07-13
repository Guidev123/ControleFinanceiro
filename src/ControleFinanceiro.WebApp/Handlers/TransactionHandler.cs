using ControleFinanceiro.Core.Commands.Transactions;
using ControleFinanceiro.Core.Extensions;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models;
using ControleFinanceiro.Core.Responses;
using ControleFinanceiro.Core.Services;
using System.Net.Http.Json;

namespace ControleFinanceiro.WebApp.Handlers
{
    public class TransactionHandler(IHttpClientFactory _clientFactory) : ITransactionHandler
    {
        private readonly HttpClient _client = _clientFactory.CreateClient(WebConfiguration.HTTP_CLIENT_NAME);
        public async Task<Response<Transaction?>> CreateAsync(CreateTransactionCommand command)
        {
            var result = await _client.PostAsJsonAsync("api/transactions", command);

            return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
                ?? new Response<Transaction?>(null, 400, "Falha na criacao da transacao");
        }

        public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionCommand command)
        {
            var result = await _client.DeleteAsync($"api/transactions/{command.Id}");

            return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
                ?? new Response<Transaction?>(null, 400, $"Falha ao excluir a transacao");
        }

        public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdCommand command)
        {
            return await _client.GetFromJsonAsync<Response<Transaction?>>($"api/transactions/{command.Id}")
                ?? new Response<Transaction?>(null, 400, "Nao foi possivel encontrar a transacao");
        }
        public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionCommand command)
        {
            var result = await _client.PutAsJsonAsync($"api/transactions/{command.Id}", command);

            return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
                ?? new Response<Transaction?>(null, 400, $"Falha na edicao da transacao {command.Title}");
        }

        public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionByPeriodCommand command)
        {
            const string dateFormat = "yyyy-MM-dd";

            var startDate = command.StartDate is not null
                ? command.StartDate.Value.ToString(dateFormat) : DateTime.Now.GetFirstDay().ToString(dateFormat);

            var endDate = command.EndDate is not null
                ? command.EndDate.Value.ToString(dateFormat) : DateTime.Now.GetLastDay().ToString(dateFormat);

            var url = $"api/transactions?startDate={startDate}&endDate={endDate}";

            return await _client.GetFromJsonAsync<PagedResponse<List<Transaction>?>>(url)
                ?? new PagedResponse<List<Transaction>?>(null, 400, "Nao foi possivel obter as transacoes");
        }
    }
}
