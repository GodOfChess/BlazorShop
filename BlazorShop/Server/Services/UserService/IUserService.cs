using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<bool> LoginUser (User user);
        Task<bool> RegisterUser(User user);
        Task<bool> CheckAdmin(User user);
    }
}
