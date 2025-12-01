using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Core.Entities
{
    public class PaymentDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string OrderId { get; set; } = string.Empty;
        public string PaymentId { get; set; } = string.Empty;
        public string Signature { get; set; } = string.Empty;

        public long Amount { get; set; }      // Razorpay returns amount in paise
        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
