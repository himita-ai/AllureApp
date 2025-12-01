using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Models
{
    public class ProductModel
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
        public int? CatId { get; set; }

        public int? SubCatId { get; set; }
        public byte[]? ImageFil{ get; set; }
    public ICollection<CartItemModel> CartItems { get; set; }
    }
}
    

