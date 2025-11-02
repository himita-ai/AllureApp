using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int? Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Currency { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsDeleted { get; set; }
  


        public int? SubCatId { get; set; }
        [ForeignKey("SubCatId")]
        public virtual SubCategory? SubCategory { get; set; }
        
    }
}

