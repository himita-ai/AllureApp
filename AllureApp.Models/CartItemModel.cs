using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Models
{
   public class CartItemModel
    {
        public int Id { get; set; }

        // Foreign keys
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }

       
        public byte[]? ImageFile { get; set; }



    }
}
