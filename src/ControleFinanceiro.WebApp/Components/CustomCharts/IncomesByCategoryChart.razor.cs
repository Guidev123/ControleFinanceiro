using ControleFinanceiro.Core.Commands.Charts;
using ControleFinanceiro.Core.Handlers;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ControleFinanceiro.WebApp.Components.CustomCharts
{
    public partial class IncomesByCategoryChartComponent : ComponentBase
    {
        public List<double> Data { get; set; } = [];
        public List<string> Labels { get; set; } = [];


        [Inject]
        public IChartHandler Handler { get; set; } = null!;
        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;


        protected override async Task OnInitializedAsync()
        {
            await GetIncomesByCategoryAsync();
        }

        private async Task GetIncomesByCategoryAsync()
        {
            var request = new GetIncomesByCategoryCommand();
            var result = await Handler.GetIncomesByCategoryChartAsync(request);

            if (!result.IsSuccess || result.Data is null)
            {
                Snackbar.Add("Falha ao obter dados do gráfico", Severity.Error);
                return;
            }

            foreach (var item in result.Data)
            {
                Labels.Add($"{item.Category} ({item.Incomes:C})");
                Data.Add(-(double)item.Incomes);
            }
        }
    }
}
