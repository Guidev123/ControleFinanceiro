using ControleFinanceiro.Core.Commands.Charts;
using ControleFinanceiro.Core.Handlers;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleFinanceiro.WebApp.Components.CustomCharts
{
    public partial class IncomesAndExpensesChartComponent : ComponentBase
    {
        public ChartOptions Options { get; set; } = new();
        public List<ChartSeries>? Series { get; set; }
        public List<string> Labels { get; set; } = [];

        [Inject]
        public IChartHandler Handler { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            var request = new GetIncomesAndExpensesCommand();
            var result = await Handler.GetIncomesAndExpensesChartAsync(request);

            if (!result.IsSuccess || result.Data is null)
            {
                Snackbar.Add("Falha ao obter dados do gráfico", Severity.Error);
                return;
            }

            var incomes = new List<double>();
            var expenses = new List<double>();

            foreach (var item in result.Data)
            {
                incomes.Add((double)item.Incomes);
                expenses.Add(-(double)item.Expenses);
                Labels.Add(GetMonthName(item.Month));
            }
            Options.YAxisTicks = 1000;
            Options.LineStrokeWidth = 5;
            Options.ChartPalette = [Colors.Green.Default, Colors.Red.Default];
            Series = [new ChartSeries{Name = "Entradas", Data = incomes.ToArray()}, new ChartSeries { Name = "Saídas", Data = incomes.ToArray() }];
            StateHasChanged();
        }
        private static string GetMonthName(int month) => new DateTime(DateTime.Now.Year, month, 1).ToString("MMMM");
    }
}
