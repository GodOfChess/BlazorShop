using Blazored.LocalStorage;
using Blazored.Toast.Services;
using BlazorShop.Client.Services.ProductService;
using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services.CartService
{
    public class CartService : ICartService
    {
        public event Action OnChange;

        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toastService;
        private readonly IProductService _productService;

        public CartService(ILocalStorageService localStorage, IToastService toastService, IProductService productService)
        {
            _localStorage = localStorage;
            _toastService = toastService;
            _productService = productService;
        }

        public async Task AddToCart(Product product)
        {
            var cart = await _localStorage.GetItemAsync<List<Product>>("cart");
            if (cart == null)
            {
                cart = new List<Product>();
            }
            cart.Add(product);
            await _localStorage.SetItemAsync("cart", cart);

            var currentProduct = await _productService.GetProduct(product.Id);
            _toastService.ShowSuccess(product.Title, "Added to cart:");

            OnChange.Invoke();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var result = new List<CartItem>();
            var cart = await _localStorage.GetItemAsync<List<Product>>("cart");

            if (cart == null)
            {
                return result;
            }
            else
            {
                foreach (var item in cart)
                {
                    var product = await _productService.GetProduct(item.Id);

                    var cartItem = new CartItem()
                    {
                        ProductId = item.Id,
                        ProductTitle = item.Title,
                        Price = int.Parse(item.Price),
                        Image = item.Img
                    };
                    result.Add(cartItem);
                }
                return result;
            }
        }

        public async Task DeleteItem(CartItem item)
        {
            var cart = await _localStorage.GetItemAsync<List<Product>>("cart");
            if (cart == null)
            {
                return;
            }
            var cartItem = cart.Find(e => e.Id == item.ProductId);
            cart.Remove(cartItem);

            await _localStorage.SetItemAsync<List<Product>>("cart", cart);
            OnChange.Invoke();
        }
    }
}
