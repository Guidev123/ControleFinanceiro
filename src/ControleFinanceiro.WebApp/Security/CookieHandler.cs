using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace ControleFinanceiro.WebApp.Security
{
    // ADICIONAR O COOKIE AO CABECALHO DAS REQUISICOES
    public class CookieHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
                           HttpRequestMessage request,
                           CancellationToken cancellationToken)
        {
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include); // INCLUINDO O ITEM

            request.Headers.Add("X-Requested-With", ["XMLHttpRequest"]); // ADICIONANDO AO CABECALHO

            return base.SendAsync(request, cancellationToken);
        }
    }
}
