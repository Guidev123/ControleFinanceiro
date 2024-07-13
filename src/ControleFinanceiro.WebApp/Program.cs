using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.WebApp;
using ControleFinanceiro.WebApp.Configurations;
using ControleFinanceiro.WebApp.Handlers;
using ControleFinanceiro.WebApp.Security;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

WebConfiguration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.ResolveDependencies();



builder.Services.AddHttpClient(WebConfiguration.HTTP_CLIENT_NAME, opt =>
{
    opt.BaseAddress = new Uri(WebConfiguration.BackendUrl);
}).AddHttpMessageHandler<CookieHandler>();





await builder.Build().RunAsync();
