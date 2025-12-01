using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Models
{
    public class PaymentDetailModel
    {
        public string RazorpayKey { get; set; } = string.Empty;
        public string OrderId { get; set; } = string.Empty;
        public string Receipt { get; set; } = string.Empty;
        public decimal GrandTotal { get; set; }
        public string Currency { get; set; } = "INR";
        public string? Description { get; set; }
    }
}

