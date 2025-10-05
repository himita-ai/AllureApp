using AllureApp.Core.Entities;
using AllureApp.Models;
using AllureApp.Repository.Interface;
using AllureApp.Service.Interface;
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

        public ResponseModel<User> InsertOrUpdateUser(UserModel user)
        {
            return _userRepo.InsertOrUpdateUser(user);
        }
    }
}
 
