using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Models.Charts
{
    public record ExpensesByCategory(string UserId, string Category, int Year, decimal Expenses)
    {
    }
}
