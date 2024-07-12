using ControleFinanceiro.Core.Commands.Account;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.WebApp.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ControleFinanceiro.WebApp.Pages.Identity
{
    public partial class LogoutPage : ComponentBase
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


        protected override async Task OnInitializedAsync()
        {
            if(await AuthenticationStateProvider.CheckAuthenticatedAsync())
            {
                await Handler.LogoutAsync();
                await AuthenticationStateProvider.GetAuthenticationStateAsync(); // ATUALIZA OS DADOS DO USUARIO
                AuthenticationStateProvider.NotifyAuthenticationStateChanged(); // AVISA PARA APLICACAO QUE O USUARIO NAO ESTA LOGADO
            } 
            await base.OnInitializedAsync();
        }
    }
}
