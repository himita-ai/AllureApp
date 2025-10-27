using AllureStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureStore.Service.Interface
{
    public interface IRoleService
    {
        int InsertOrUpdateRole(AdminRoleModel model);
        IEnumerable<AdminRoleModel> GetAllRoles();

        bool DeleteRole(string roleName);

    }
}
