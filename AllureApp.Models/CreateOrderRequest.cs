using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Models
{
    public class CreateOrderRequest
    {
        public List<int> ProductIds { get; set; } = new();
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}
