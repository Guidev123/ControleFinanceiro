using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Commands.Orders
{
    public class CreateOrderCommand : Command
    {
        public long ProductId { get; set; }
        public long? VoucherId { get; set; }
    }
}
