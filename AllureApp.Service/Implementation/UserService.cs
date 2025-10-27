using AllureApp.Core.Entities;
using AllureApp.Models;
using AllureApp.Repository.Interface;
using AllureApp.Service.Interface;
using AllureStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public bool AssignRoleToUsers(AssignRoleModel role)
        {
            return _userRepo.AssignRoleToUsers(role);
        }

        public IEnumerable<AdminNavItemModel> GetAdminNavItems()
        {
           return _userRepo.GetAdminNavItems();
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public ResponseModel<User> InsertOrUpdateUser(UserModel user)
        {
            return _userRepo.InsertOrUpdateUser(user);
        }

        public UserModel VerifyUser(string email, string password)
        {
            return _userRepo.VerifyUser(email, password);

        }
    }
}
 
