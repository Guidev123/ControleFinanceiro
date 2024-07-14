using ControleFinanceiro.Core.Commands.Charts;
using ControleFinanceiro.Core.Handlers;
using ControleFinanceiro.Core.Models.Charts;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ControleFinanceiro.WebApp.Pages
{
    public partial class HomePage : ComponentBase
    {
        #region Properties

        public bool ShowValues { get; set; } = true;
        public FinancialSummary? Summary { get; set; }

        #endregion

        #region Services

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public IChartHandler Handler { get; set; } = null!;

        #endregion

        #region Overrides

        protected override async Task OnInitializedAsync()
        {
            var request = new GetFinancialSummaryCommand();
            var result = await Handler.GetFinancialSummaryChartAsync(request);
            if (result.IsSuccess)
                Summary = result.Data;
        }

        #endregion

        #region Methods

        public void ToggleShowValues()
            => ShowValues = !ShowValues;

        #endregion
    }
}
