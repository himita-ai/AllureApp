using AllureStore.Models;
using AllureStore.Repository.Interface;
using AllureStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureStore.Service.Implementation
{
    public class RolesService : IRoleService
    {
        private IRoleRepo _roleRepo;
        public RolesService(IRoleRepo roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public bool DeleteRole(string roleName)
        {
            return _roleRepo.DeleteRole(roleName);
        }

        public IEnumerable<AdminRoleModel> GetAllRoles()
        {
            return _roleRepo.GetAllRoles();
        }

        public int InsertOrUpdateRole(AdminRoleModel model)
        {
            return _roleRepo.InsertOrUpdateRole(model);
        }
    }
}