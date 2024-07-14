using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Commands.Categories
{
    public class UpdateCategoryCommand : Command
    {
        public long Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa conter de {2} a {1} caracteres", MinimumLength = 5)]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(255, ErrorMessage = "O campo {0} precisa conter de {2} a {1} caracteres", MinimumLength = 5)]
        public string? Description { get; set; } 
    }
}
