using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Models.Charts
{
    public record FinancialSummary(string UserId, decimal Incomes, decimal Expenses)
    {
        public decimal Total => Incomes - (Expenses < 0 ? -Expenses : Expenses); 
    }
}
