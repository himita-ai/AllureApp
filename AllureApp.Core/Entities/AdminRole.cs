using AllureApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureStore.Core.Entities
{
    public class AdminRole
    {
        public AdminRole()
        {
            Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? View { get; set; }
        public bool? Edit { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}