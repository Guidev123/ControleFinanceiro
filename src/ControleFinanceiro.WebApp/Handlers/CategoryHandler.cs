using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models;
using ControleFinanceiro.Core.Responses;
using ControleFinanceiro.Core.Services;
using System.Net.Http.Json;

namespace ControleFinanceiro.WebApp.Handlers
{
    public class CategoryHandler(IHttpClientFactory _clientFactory) : ICategoryHandler
    {
        private readonly HttpClient _client = _clientFactory.CreateClient(WebConfiguration.HTTP_CLIENT_NAME);
        public async Task<Response<Category?>> CreateAsync(CreateCategoryCommand command)
        {
            var result = await _client.PostAsJsonAsync("api/categories", command);

            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                ?? new Response<Category?>(null, 400, "Falha na criacao da categoria");
        }

        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryCommand command)
        {
            var result = await _client.PutAsJsonAsync($"api/categories/{command.Id}", command);

            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                ?? new Response<Category?>(null, 400, $"Falha na edicao da categoria {command.Title}");
        }
        public async Task<Response<Category?>> DeleteAsync(DeleteCategoryCommand command)
        {
            var result = await _client.DeleteAsync($"api/categories/{command.Id}");

            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                ?? new Response<Category?>(null, 400, $"Falha ao excluir a categoria");
        }

        public async Task<PagedResponse<List<Category>>> GetAllAsync(GetAllCategoryCommand command)
        {
            return await _client.GetFromJsonAsync<PagedResponse<List<Category>>>("api/categories")
                ?? new PagedResponse<List<Category>>(null, 400, "Nao foi possivel obter as categorias");
        }

        public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdCommand command)
        {
            return await _client.GetFromJsonAsync<Response<Category?>>($"api/categories/{command.Id}")
                ?? new Response<Category?>(null, 400, "Nao foi possivel encontrar a categoria");
        }

    }
}
