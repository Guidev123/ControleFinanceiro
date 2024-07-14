using ControleFinanceiro.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Commands.Transactions
{
    public class CreateTransactionCommand : Command
    {
        [Display(Name = "Título")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa conter de {2} a {1} caracteres", MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Tipo Transação")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public ETransactionType TransactionType { get; set; } = ETransactionType.Withdraw;

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo {0} esta invalido")]
        public decimal Amount { get; set; }


        [Required(ErrorMessage = "O campo {0} esta invalido")]
        public long CategoryId { get; set; }



        [Required(ErrorMessage = "O campo {0} esta invalido")]
        public DateTime? PaidOrReceivedAt { get; set; }
    }
}
