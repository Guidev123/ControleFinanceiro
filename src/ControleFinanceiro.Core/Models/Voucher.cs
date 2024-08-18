using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Core.Models
{
    public class Voucher
    {
        [Key]
        public long Id { get; set; }
        public string VoucherCode { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsUsed { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive => StartDate >= DateTime.UtcNow && EndDate <= EndDate && IsUsed is false;
    }
}
