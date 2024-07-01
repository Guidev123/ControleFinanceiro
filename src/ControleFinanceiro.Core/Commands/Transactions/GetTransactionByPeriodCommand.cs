using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Commands.Transactions
{
    public class GetTransactionByPeriodCommand : PagedCommand
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
