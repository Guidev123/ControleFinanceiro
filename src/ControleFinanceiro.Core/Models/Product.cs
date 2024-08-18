using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Core.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
    }
}
