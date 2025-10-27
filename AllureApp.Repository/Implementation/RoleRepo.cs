using AllureApp.Core.DBContext;
using AllureApp.Core.Entities;
using AllureApp.Repository;
using AllureApp.Repository.Interface;
using AllureStore.Core.Entities;
using AllureStore.Models;
using AllureStore.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureStore.Repository.Implementation
{
    public class RoleRepo : Repository<AdminRole>, IRoleRepo
    {

        private readonly AllureAppContext _context;

        public RoleRepo(AllureAppContext context) : base(context)
        {
            _context = context;
        }

        public bool DeleteRole(string roleName)
        {
            throw new NotImplementedException();
        }

       

        public int InsertOrUpdateRole(AdminRoleModel model)
        {
            int result = 0;
            try
            {
                var roleExist = _context.AdminRole.FirstOrDefault(c => c.RoleName.Equals(model.RoleName));
                if (roleExist != null)
                {
                    roleExist.IsDeleted = false;
                    roleExist.View = Convert.ToBoolean(model.View);
                    roleExist.Edit = Convert.ToBoolean(model.Edit);

                    _context.SaveChanges();
                    result = 1;
                }
                else
                {
                    var role = new AdminRole()
                    {
                        RoleName = model.RoleName,
                        View = Convert.ToBoolean(model.View),
                        Edit = Convert.ToBoolean(model.Edit),
                        IsDeleted = false
                    };
                    _context.AdminRole.Add(role);
                    _context.SaveChanges();
                    result = 1;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<AdminRoleModel> GetAllRoles()
        {
            try
            {
                var roles = _context.AdminRole.Where(r => r.IsDeleted == false).Select(r => new AdminRoleModel
                {
                    RoleName = r.RoleName,
                    View = r.View.ToString(),
                    Edit = r.Edit.ToString()
                }).ToList();
                return roles;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
