using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ControleFinanceiro.WebApp.Pages.Categories
{
    public partial class ListCategoryPage : ComponentBase
    {
        // PROPERTIES
        public bool IsBusy { get; set; } = false;
        public List<Category> Categories { get; set; } = [];
        public string SearchTerm { get; set; } = string.Empty;


        // SERVICES
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public ICategoryHandler Handler { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        // METHODS
        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;

            try
            {
                var request = new GetAllCategoryCommand();
                var result = await Handler.GetAllAsync(request);

                if (result.IsSuccess)
                {
                    Categories = result.Data ?? [];
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
            var result = await DialogService.ShowMessageBox("Atenção", $"Ao prosseguir a categoria {title} será excluída. Deseja continuar?", yesText: "Excluir", cancelText: "Cancelar");

            if (result is true)
                await OnDeleteAsync(id, title);

            StateHasChanged();
        }

        public async Task OnDeleteAsync(long id, string title)
        {
            try
            {
                var request = new DeleteCategoryCommand { Id = id };
                await Handler.DeleteAsync(request);
                Categories.RemoveAll(x => x.Id == id);
                Snackbar.Add($"Categoria {title} excluída", Severity.Success);
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }



        public Func<Category, bool> Filter => category =>
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
                return true;

            if (category.Id.ToString().Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (category.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            if (category.Description is not null &&
                category.Description.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
    }
}
