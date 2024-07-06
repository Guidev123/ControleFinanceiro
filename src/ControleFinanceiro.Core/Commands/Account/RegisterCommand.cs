using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Commands.Account
{
    public class RegisterCommand : Command
    {
        [Required(ErrorMessage = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha inválida")]
        public string Password { get; set; } = string.Empty;
    }
}
