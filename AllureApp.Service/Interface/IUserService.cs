using AllureApp.Core.Entities;
using AllureApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Service.Interface
{
    public interface IUserService
    {
        ResponseModel<User> InsertOrUpdateUser(UserModel user);
    }
}
