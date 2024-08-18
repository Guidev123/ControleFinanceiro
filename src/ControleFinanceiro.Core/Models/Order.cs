using ControleFinanceiro.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Core.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public long? VoucherId { get; set; }
        public Voucher? Voucher { get; set; } 
        public string OrderCode { get; set; } = Guid.NewGuid().ToString("N")[..8];
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public EPaymentGateway Gateway { get; set; } = EPaymentGateway.Stripe;
        public EOrderStatus OrderStatus { get; set; } = EOrderStatus.WaitingPayment;
        public string? ExternalReference { get; set; } // NUMERO DO PEDIDO LA NO GATEWAY
        public string UserId { get; set; } = string.Empty;
        public decimal Total => Product.Price - (Voucher?.Amount ?? 0); 
    }
}
