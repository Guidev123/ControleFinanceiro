using ControleFinanceiro.WebApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddMudServices();



builder.Services.AddHttpClient(Configuration.HTTP_CLIENT_NAME, opt =>
{
    opt.BaseAddress = new Uri(Configuration.BackendUrl);
}).AddHttpMessageHandler<CookieHandler>();

await builder.Build().RunAsync();
