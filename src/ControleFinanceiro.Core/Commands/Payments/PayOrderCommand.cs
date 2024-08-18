using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Commands.Payments
{
    public class PayOrderCommand : Command
    {
        public long Id { get; set; }
        public string ExternalReference { get; set; } = string.Empty;
    }
}
