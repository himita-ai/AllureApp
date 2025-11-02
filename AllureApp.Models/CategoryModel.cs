using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Models
{
    public class CategoryModel
    {
       
        public int Id { get; set; }
        public string?Name { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<SubCategoryModel> SubCategories { get; set; }

    }
}
