using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Models
{
    public class OrderProductDto
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderModel
    {
        public string? CartId { get; set; }
        public int UserId { get; set; }
        public string? Receipt { get; set; }

        // Razorpay response fields
        public string? rzp_OrderId { get; set; }
        public string? rzp_PaymentId { get; set; }
        public string? rzp_Signature { get; set; }

        public List<OrderProductDto> Products { get; set; } = new();
    }
}
