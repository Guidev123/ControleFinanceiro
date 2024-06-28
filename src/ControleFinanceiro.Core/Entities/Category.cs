using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Entities
{
    public class Category
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
