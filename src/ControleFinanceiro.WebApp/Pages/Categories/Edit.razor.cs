using ControleFinanceiro.Core.Commands.Categories;
using ControleFinanceiro.Core.Handlers;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ControleFinanceiro.WebApp.Pages.Categories
{
    public partial class EditCategoryPage : ComponentBase
    {
        // PROPERTIES 
        public bool IsBusy { get; set; } = false;
        public UpdateCategoryCommand InputModel { get; set; } = null!;

        [Parameter]
        public string Id { get; set; } = string.Empty;

        // SERVICES
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public ICategoryHandler Handler { get; set; } = null!;

        // OVERRIDE
        protected override async Task OnInitializedAsync()
        {
            GetCategoryByIdCommand? request = null;

            try
            {
                request = new GetCategoryByIdCommand
                {
                    Id = long.Parse(Id)
                };
            }

            catch
            {
                Snackbar.Add("Parametro inválido", Severity.Info);
            }

            if (request is null) return;

            IsBusy = true;

            try
            {
                var response = await Handler.GetByIdAsync(request);
                if (response.IsSuccess && response.Data is not null)
                {
                    InputModel = new UpdateCategoryCommand
                    {
                        Id = response.Data.Id,
                        Title = response.Data.Title,
                        Description = response.Data.Description
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
        // METHODS
        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.UpdateAsync(InputModel);
                if (result.IsSuccess)
                {
                    Snackbar.Add("Categoria atualizada", Severity.Success);
                    NavigationManager.NavigateTo("/categorias");
                }
            }
            catch(Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
            finally
            {
                IsBusy= false;
            }
        }
    }
}
