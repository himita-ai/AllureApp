using AllureStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureStore.Repository.Interface
{
    public interface IRoleRepo
    {
        int InsertOrUpdateRole(AdminRoleModel model);

        IEnumerable<AdminRoleModel> GetAllRoles();
        bool DeleteRole(string roleName);

    }
}