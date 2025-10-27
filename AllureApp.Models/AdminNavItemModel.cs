using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureStore.Models
{
    public class AdminNavItemModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? icon { get; set; }
        public int? ParentId { get; set; }
        public decimal? SortOrder { get; set; }
        public bool? Enabled { get; set; }

        public IEnumerable<AdminNavItemModel>? Children { get; set; }
    }
}
