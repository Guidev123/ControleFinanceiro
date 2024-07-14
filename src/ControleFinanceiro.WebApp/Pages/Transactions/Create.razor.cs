using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Commands.Transactions;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ControleFinanceiro.WebApp.Pages.Transactions
{
    public partial class CreateTransactionPage : ComponentBase
    {
        // PROPERTIES
        public bool IsBusy { get; set; } = false;
        public CreateTransactionCommand InputModel { get; set; } = new();
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
            try
            {
                IsBusy = true;
                var request = new GetAllCategoryCommand();
                var result = await CategoryHandler.GetAllAsync(request);

                if (result.IsSuccess) Categories = result.Data ?? []; 
                InputModel.CategoryId = Categories.FirstOrDefault()?.Id ?? 0;

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


        // METHODS

        public async Task OnValidSubmitAsync()  
        {
            IsBusy = true;

            try
            {
                var result = await TransactionHandler.CreateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/transacoes/historico");
                }
                else Snackbar.Add(result.Message, Severity.Error);
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
