using FirsBlog_Core.DTOs.Users;
using FirsBlog_DataLayer.Context;
using System;
using System.Linq;
using FirsBlog_DataLayer.Entities;
using FirsBlog_Core.Utilities;

namespace FirsBlog_Core.Services.Users
{
    public class UserService : IUserService
    {
        private readonly BlogContext _context;
        public UserService(BlogContext context)
        {
            _context = context;
        }

        public UserDTO IsUserExisted(UserLoginDTO userLoginDTO)
        {
            var HashedPassword = userLoginDTO.Password.EncodeToMd5();
            var User = _context.Users.FirstOrDefault(u => u.UserName == userLoginDTO.Username && u.Password == HashedPassword);
            if (User == null)
            {
                return null;
            }
            var UserDTO = new UserDTO()
            {
                FullName = User.FullName,
                Password = User.Password,
                RegisterTime = User.CreationDate,
                UserId = User.Id,
                UserName = User.UserName,
                UserRole = User.UserRole
            };
            return UserDTO;
        }

        public OperationResult RegisterUser(UserRegisterDTO userRegisterDTO)
        {

            var IsUserNameExisted = _context.Users.Any(u => u.UserName == userRegisterDTO.UserName);
            if (IsUserNameExisted)

                return OperationResult.Error("نام کاربری تکراری است");


            var HashPassword = userRegisterDTO.Password.EncodeToMd5();
            _context.Users.Add(new User()
            {
                UserName = userRegisterDTO.UserName,
                FullName = userRegisterDTO.FullName,
                Password = HashPassword,
                IsDelete = false,
                CreationDate = DateTime.Now
            });
            _context.SaveChanges();
            return OperationResult.Success();
        }
    }
}
