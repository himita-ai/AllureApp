using AllureStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Core.Entities
{
  public class User
    {
      
            public int Id { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Address { get; set; }
            public DateTime? CreatedDate { get; set; }
            public bool? IsDeleted { get; set; }
            public DateTime? PasswordExpiryDate { get; set; }
        public int? RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual AdminRole? Role { get; set; }


    }
}
