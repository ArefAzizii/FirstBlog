using FirsBlog_Core.DTOs.Users;
using FirsBlog_Core.Utilities;
using FirsBlog_DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirsBlog_Core.Services.Users
{
    public interface IUserService
    {
        OperationResult RegisterUser(UserRegisterDTO userRegisterDTO);
        UserDTO IsUserExisted(UserLoginDTO userLoginDTO);
    }
     
}
