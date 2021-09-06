using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.DataAccess.Entities;
using Web.Modules.User.Dto;
using Web.Modules.Utils.Dto;

namespace Web.Modules.User.Interfaces
{
    public interface IUserService
    {
        Task<ResponseResultDto> CreateUser(UserLoginDto user);
        Task<List<UserTable>> GetUserAll();
        Task<ResponseResultDto> CreateRole(RoleDto role);
    }
}