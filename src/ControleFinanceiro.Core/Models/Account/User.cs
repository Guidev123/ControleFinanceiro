using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Models.Account
{
    public class User
    {
        public string Email { get; set; } = string.Empty;
        public bool IsEmailConfirmed { get; set; }
        public Dictionary<string, string> Claims { get; set; } = [];
    }
}
