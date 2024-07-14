using ControleFinanceiro.MinimalAPI.Configuration;
using ControleFinanceiro.MinimalAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddEnvConfig();
builder.Services.AddDbContextsConfig(builder.Configuration);
builder.Services.AddSecurityConfig();
builder.AddCorsConfig();
builder.Services.AddDocumentationConfig(builder.Configuration);
builder.Services.ResolveDependencies(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseSecurity();
app.MapEndpoints();

app.Run();