using Blazored.LocalStorage;
using Blazored.Toast.Services;
using BlazorShop.Client.Services.CartService;
using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;

        public event Action OnChange;

        public UserService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<bool> LoginUser(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user/loguser", user);
            if (response.IsSuccessStatusCode == false)
            {
                return false;
            }
            else
            {
                await CheckAdmin(user);
                var cart = await _localStorage.GetItemAsync<List<Product>>("cart");
                if (cart != null)
                {
                    cart.Clear();
                    await _localStorage.SetItemAsync("cart", cart);
                }
                await _localStorage.SetItemAsStringAsync("user", user.UserName);
                OnChange.Invoke();
                return true;
            }
        }

        public async Task CheckAdmin(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user/checkuser", user);
            if (response.IsSuccessStatusCode)
            {
                await _localStorage.SetItemAsync("admin", true);
            }
        }


        public async Task<bool> RegisterUser(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/user", user);
            if (response.IsSuccessStatusCode == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("api/user");
        }
    }
}
