using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Models.Charts
{
    public record IncomesAndExpenses(string UserId, int Month, int Year, decimal Incomes, decimal Expenses)
    {
    }
}
