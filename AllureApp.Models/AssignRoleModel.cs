using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureStore.Models
{
    public class AssignRoleModel
    {
        public int[]? UserIds { get; set; }
        public string? RoleName { get; set; }
    }
}