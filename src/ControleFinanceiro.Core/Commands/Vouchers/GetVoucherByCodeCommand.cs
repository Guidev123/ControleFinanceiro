using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Commands.Vouchers
{
    public class GetVoucherByCodeCommand : Command
    {
        public string VoucherCode { get; set; } = string.Empty;
    }
}
