using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public List<Product> Products { get; set; } = new List<Product>();

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoadProducts()
        {
            Products = await _httpClient.GetFromJsonAsync<List<Product>>("api/Product");
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/Product/{id}");
        }

        public async Task AddProduct(Product product)
        {
            await _httpClient.PostAsJsonAsync("api/Product", product);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"api/Product/{id}");
        }
    }
}
