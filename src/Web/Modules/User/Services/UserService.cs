using System.Threading.Tasks;
using Web.Modules.User.Dto;
using Web.Modules.User.Interfaces;
using Web.Modules.Utils.Dto;
using Web.DataAccess.Contexts;
using Web.Modules.Utils.Interfaces;
using System;
using System.Linq;
using Web.DataAccess.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web.Modules.User.Services
{
    public class UserService : IUserService
    {
        private DataContext _dataContext;
        private IPasswordService _passwordService;

        public UserService(
            DataContext dataContext,
            IPasswordService passwordService
        )
        {
            _dataContext = dataContext;
            _passwordService = passwordService;
        }

        public async Task<ResponseResultDto> CreateRole(RoleDto role)
        {
            using (var context = _dataContext)
            {
                var newRole = new RoleTable
                {
                    Name = role.Name,
                    Guid = Guid.NewGuid(),
                    IsActive = role.IsActive,
                    CreateAt = DateTime.Now
                };

                await context.AddAsync(newRole);
                await context.SaveChangesAsync();

                return new ResponseResultDto
                {
                    Result = true,
                    Message = "Create role success"
                };
            }
        }

        public async Task<ResponseResultDto> CreateUser(UserLoginDto user)
        {
            using (var context = _dataContext)
            {
                var checkUserAlreayExists = context.User
                    .FirstOrDefault(x => x.Username == user.Username);

                if (checkUserAlreayExists != null)
                {
                    return new ResponseResultDto
                    {
                        Result = false,
                        Message = $"Username {user.Username} already exists"
                    };
                }

                Guid salt = Guid.NewGuid();
                string passwordHashed = _passwordService.HashPassword(user.Password, salt.ToString());

                var newUser = new UserTable
                {
                    Username = user.Username,
                    Guid = Guid.NewGuid(),
                    Salt = salt,
                    Password = passwordHashed,
                    CreateAt = DateTime.Now,
                    IsActive = 1
                };

                await context.AddAsync(newUser);
                await context.SaveChangesAsync();

                return new ResponseResultDto
                {
                    Result = true,
                    Message = "Create user success"
                };
            }
        }

        public async Task<List<UserTable>> GetUserAll()
        {
            using (var context = _dataContext)
            {
                var users = await context.User
                    .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                    .ToListAsync();

                return users;
            }
        }
    }
}