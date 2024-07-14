using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Commands.Transactions;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ControleFinanceiro.WebApp.Pages.Transactions
{
    public partial class EditTransactionPage : ComponentBase
    {
        // PROPERTIES

        [Parameter]
        public string Id { get; set; } = string.Empty;

        public bool IsBusy { get; set; } = false;
        public UpdateTransactionCommand InputModel { get; set; } = new();
        public List<Category> Categories { get; set; } = [];

        // SERVICES
        [Inject]
        public ITransactionHandler TransactionHandler { get; set; } = null!;

        [Inject]
        public ICategoryHandler CategoryHandler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        // OVERRIDE
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            await GetTransactionByIdAsync();
            await GetCategoriesAsync();
        }

        // METHODS

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await TransactionHandler.UpdateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add("Lançamento atualizado", Severity.Success);
                    NavigationManager.NavigateTo("/transacoes/historico");
                }
                else
                {
                    Snackbar.Add(result.Message, Severity.Error);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GetTransactionByIdAsync()
        {
            try
            {
                IsBusy = true;
                var request = new GetTransactionByIdCommand
                {
                    Id = long.Parse(Id)
                };
                var result = await TransactionHandler.GetByIdAsync(request);

                if (result.IsSuccess && result.Data is not null)
                {
                    InputModel = new UpdateTransactionCommand
                    {
                        CategoryId = result.Data.CategoryId,
                        PaidOrReceivedAt = result.Data.PaidOrReceivedAt,
                        Title = result.Data.Title,
                        TransactionType = result.Data.TransactionType,
                        Amount = result.Data.Amount,
                        Id = result.Data.Id
                    };
                }

            }

            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }

            finally
            {
                IsBusy = false;
            }
        }
        private async Task GetCategoriesAsync()
        {
            IsBusy = true;
            try
            {
                var request = new GetAllCategoryCommand();
                var result = await CategoryHandler.GetAllAsync(request);
                if (result.IsSuccess)
                {
                    Categories = result.Data ?? [];
                    InputModel.CategoryId = Categories.FirstOrDefault()?.Id ?? 0;
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
