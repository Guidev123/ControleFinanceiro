using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Commands.Transactions;
using ControleFinanceiro.Core.Extensions;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ControleFinanceiro.WebApp.Pages.Transactions
{
    public partial class ListTransactionPage : ComponentBase
    {
        // PROPERTIES
        public bool IsBusy { get; set; } = false;
        public List<Transaction> Transactions { get; set; } = [];
        public string SearchTerm { get; set; } = string.Empty;
        public int CurrentYear { get; set; } = DateTime.Now.Year;
        public int CurrentMonth { get; set; } = DateTime.Now.Month;
        public int[] Years { get; set; } =
        {
            DateTime.Now.Year,
            DateTime.Now.AddYears(-1).Year,
            DateTime.Now.AddYears(-2).Year,
            DateTime.Now.AddYears(-3).Year
        };

        // SERVICES 

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;
        [Inject]
        public IDialogService DialogService { get; set; } = null!;
        [Inject]
        public ITransactionHandler Handler { get; set; } = null!;

        // OVERRIDE
        protected override async Task OnInitializedAsync() => await GetTransactions();


        // METHODS
        private async Task GetTransactions()
        {
            IsBusy = true;
            try
            {
                var request = new GetTransactionByPeriodCommand
                {
                    StartDate = DateTime.Now.GetFirstDay(CurrentYear, CurrentMonth),
                    EndDate = DateTime.Now.GetLastDay(CurrentYear, CurrentMonth),
                    PageNumber = 1,
                    PageSize = 1000
                };
                var result = await Handler.GetByPeriodAsync(request);
                if (result.IsSuccess)
                {
                    Transactions = result.Data ?? [];
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

        public async void OnDeleteButtonClickedAsync(long id, string title)
        {
            var result = await DialogService.ShowMessageBox("Atenção", $"Ao prosseguir a transação {title} será excluída. Deseja continuar?",
                yesText: "Excluir", cancelText: "Cancelar");

            if (result is true) await OnDeleteAsync(id, title);

            StateHasChanged();
        }

        public async Task OnDeleteAsync(long id, string title)
        {
            try
            {
                var request = new DeleteTransactionCommand { Id = id };
                await Handler.DeleteAsync(request);
                Transactions.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Categoria {title} excluída", Severity.Success);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public async Task OnSearchAsync()
        {
            await GetTransactions();
            StateHasChanged();
        }

        public Func<Transaction, bool> Filter => transaction =>
        {
            if (string.IsNullOrWhiteSpace(SearchTerm)) return true;

            if (transaction.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)) return true;

            if (transaction.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)) return true;

            return false;
        };
    }
}