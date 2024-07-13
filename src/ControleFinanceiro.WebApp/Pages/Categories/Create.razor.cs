using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Handlers;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ControleFinanceiro.WebApp.Pages.Categories
{
    public partial class CreateCategoryPage : ComponentBase
    {
        // PROPERTIES
        public bool IsBusy {  get; set; } = false;
        public CreateCategoryCommand InputModel { get; set; } = new();


        // SERVICES
        [Inject]
        public ICategoryHandler Handler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;



        // METHODS

        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.CreateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/categorias");
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
