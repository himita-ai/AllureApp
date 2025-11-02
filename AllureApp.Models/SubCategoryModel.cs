using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Models
{
    public class SubCategoryModel
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        public string? Name { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual CategoryModel? Category { get; set; }
        public virtual ICollection<ProductModel>? Products { get; set; }
    }
}
