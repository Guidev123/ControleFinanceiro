using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Commands.Orders
{
    public class GetOrderByCodeCommand : Command
    {
        public string OrderCode { get; set; } = string.Empty;
    }
}
