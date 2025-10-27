using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Core.Entities
{
  public  class Category
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }
        public int Id { get; set; }
        public string? Cat_Name { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<SubCategory>? SubCategories { get; set; }
    }
}
