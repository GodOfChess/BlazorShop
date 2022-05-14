using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services.UserService
{
    public interface IUserService
    {
        public event Action OnChange;
        public Task<bool> LoginUser(User user);
        public Task<bool> RegisterUser(User user);
        public Task CheckAdmin(User user);
        public Task<List<User>> GetAllUsers();
    }
}
