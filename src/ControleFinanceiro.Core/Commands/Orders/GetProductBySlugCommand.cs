using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Commands.Orders
{
    public class GetProductBySlugCommand : Command
    {
        public string Slug { get; set; } = string.Empty;
    }
}
