using ControleFinanceiro.WebApp;
using ControleFinanceiro.WebApp.Configurations;
using ControleFinanceiro.WebApp.Security;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

WebConfiguration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.ResolveDependencies();

builder.Services.AddMudServices();


builder.Services.AddHttpClient(WebConfiguration.HTTP_CLIENT_NAME, opt =>
{
    opt.BaseAddress = new Uri(WebConfiguration.BackendUrl);
}).AddHttpMessageHandler<CookieHandler>();




builder.Services.AddLocalization();
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");


await builder.Build().RunAsync();
