using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(Product product);

        Task<List<CartItem>> GetCartItems();

        Task DeleteItem(CartItem item);
    }
}
