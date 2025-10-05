using AllureApp.Core.DBContext;
using AllureApp.Core.Entities;
using AllureApp.Models;

using AllureApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AllureApp.Repository
{
    public class UserRepo : Repository<User>, IUserRepo
    {
         
        private readonly AllureAppContext _context;

        public UserRepo(AllureAppContext context) : base(context)
        {
            _context = context;
        }

        public ResponseModel<User> InsertOrUpdateUser(UserModel user)
        {
            var response = new ResponseModel<User>();

            if (user == null)
                return new ResponseModel<User> { Success = false, Status = "User model is null" };

            try
            {
                User? existingUser = null;

                // Update only if Id > 0
                if (user.Id > 0)
                {
                    existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
                }

                if (existingUser != null)
                {
                    existingUser.FirstName = user.FirstName;
                    existingUser.LastName = user.LastName;
                    existingUser.Email = user.Email;
                    existingUser.Password = user.Password;
                    existingUser.PhoneNumber = user.PhoneNumber;
                    existingUser.Address = user.Address;

                    _context.Users.Update(existingUser);
                    _context.SaveChanges();

                    response.Success = true;
                    response.Status = "User updated successfully";
                    response.Result = existingUser;
                }
                else
                {
                    var adduser = new User
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Password = user.Password,
                        PhoneNumber = user.PhoneNumber,
                        Address = user.Address,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        PasswordExpiryDate = DateTime.Now.AddMonths(6)
                    };

                    _context.Users.Add(adduser);
                    _context.SaveChanges();

                    response.Success = true;
                    response.Status = "User added successfully";
                    response.Result = adduser;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Status = ex.Message;
                response.Result = null;
            }

            return response;
        }

        public UserModel VerifyUser(string email, string password)
        {
            var ml = new UserModel();
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Email.Equals(email) && x.Password == password && x.PasswordExpiryDate > DateTime.Now);
                if (user != null)
                {
                    ml.Id = user.Id;
                    ml.FirstName = user.FirstName;
                    ml.LastName = user.LastName;
                    ml.Email = user.Email;

                }
                return ml;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
    




//public int InsertOrUpdateUser(UserModel user)
//{
//    if (_context == null)
//        throw new InvalidOperationException("Database context is not initialized.");

//    int result = 0;
//    try
//    {
//        var userExist = _context.Users.FirstOrDefault(x => x.Id == user.Id);
//        if (userExist != null)
//        {
//            // Update existing user
//            userExist.FirstName = user.FirstName;
//            userExist.LastName = user.LastName;
//            userExist.Email = user.Email;
//            userExist.Password = user.Password;
//            userExist.Address = user.Address;
//            userExist.PhoneNumber = user.PhoneNumber;
//            _context.Users.Update(userExist);
//            _context.SaveChanges();
//            result = 0; // Indicate update
//        }
//        else
//        {
//            // Add new user
//            var adduser = new User
//            {
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Email = user.Email,
//                Password = user.Password,
//                IsDeleted = false,
//                CreatedDate = DateTime.Now,
//                PasswordExpiryDate = DateTime.Now.AddMonths(6),
//                Address = user.Address,
//                PhoneNumber = user.PhoneNumber,
//            };
//            Add(adduser);      // Use base method
//            result = SaveChanges();     // Use base method

//            Console.WriteLine(_dbContext.Database.GetDbConnection().ConnectionString);
//            Console.WriteLine("Connected DB: " + _dbContext.Database.GetDbConnection().ConnectionString);




//        }
//        return result;
//    }
//    catch (Exception ex)
//    {
//        throw;
//    }


//{

//    int result = 0;
//    if (_dbContext == null)
//        throw new InvalidOperationException("Database context is not initialized.");

//    try
//    {
//        var userExist = _context.Users.FirstOrDefault(x => x.Id == user.Id);
//        if (userExist != null)
//        {

//        }
//        else
//        {
//            var adduser = new User
//            {
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Email = user.Email,
//                Password = user.Password,
//                IsDeleted = false,
//                CreatedDate = DateTime.Now,
//                PasswordExpiryDate = DateTime.Now.AddMonths(6),
//                Address = user.Address,
//                PhoneNumber = user.PhoneNumber,
//            };
//            _context.Users.Add(adduser);
//            _context.SaveChanges();
//            result = 1;
//        }
//        return result;

//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//}

//        public UserModel VerifyUser(string email, string password)
//        {
//            var ml = new UserModel();
//            try
//            {
//                var user = _context.Users.FirstOrDefault(x => x.Email.Equals(email) && x.Password == password && x.PasswordExpiryDate > DateTime.Now);
//                if (user != null)
//                {
//                    ml.Id = user.Id;
//                    ml.FirstName = user.FirstName;
//                    ml.LastName = user.LastName;
//                    ml.Email = user.Email;

//                }
//                return ml;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//    }
//}
