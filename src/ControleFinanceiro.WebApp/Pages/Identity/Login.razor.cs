using ControleFinanceiro.Core.Commands.Account;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.WebApp.Security;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;

namespace ControleFinanceiro.WebApp.Pages.Identity
{
    public partial class LoginPage : ComponentBase
    {
        // DEPENDENCIES
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IAccountHandler Handler { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

        // PROPRIEDADES
        public bool IsBusy { get; set; } = false;
        public LoginCommand InputModel { get; set; } = new();


        // OVERRIDE
        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity is not null && user.Identity.IsAuthenticated) NavigationManager.NavigateTo("/");

        }

        // METHODS
        public async Task OnValidSubmitAsync()
        {
            IsBusy = true;

            try
            {
                var result = await Handler.LoginAsync(InputModel);

                if (result.IsSuccess)
                {
                    await AuthenticationStateProvider.GetAuthenticationStateAsync();
                    AuthenticationStateProvider.NotifyAuthenticationStateChanged();

                    Snackbar.Add(result.Message, Severity.Success);
                    NavigationManager.NavigateTo("/");
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
    }
}
