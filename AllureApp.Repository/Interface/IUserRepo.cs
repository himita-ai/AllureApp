using AllureApp.Core.Entities;
using AllureApp.Models;
using AllureStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Repository.Interface
{
    public interface IUserRepo
    {
        ResponseModel<User> InsertOrUpdateUser(UserModel user);
        UserModel VerifyUser(string email, string password);
        IEnumerable<UserModel> GetAllUsers();
        IEnumerable<AdminNavItemModel> GetAdminNavItems();
        bool AssignRoleToUsers(AssignRoleModel role);
    }
}
