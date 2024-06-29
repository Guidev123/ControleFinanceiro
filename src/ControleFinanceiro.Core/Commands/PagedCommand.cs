using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Commands
{
    public abstract class PagedCommand : Command
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;

    }
}
