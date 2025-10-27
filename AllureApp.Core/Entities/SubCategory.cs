using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Core.Entities
{
    public  class SubCategory
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        public string? SubCat_Name { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        [ForeignKey("CatId")]
        public virtual Category? Category { get; set; }
        public virtual ICollection<Product>? Products { get; set; }

    }
}
