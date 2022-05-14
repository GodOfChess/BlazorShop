using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetProduct(int id);
        public Task<bool> AddProduct(Product product);
        public Task DeleteProduct(int id);
    }
}
