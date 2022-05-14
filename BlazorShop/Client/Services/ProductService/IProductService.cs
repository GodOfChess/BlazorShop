using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services.ProductService
{
    public interface IProductService
    {
        public List<Product> Products { get; set; }
        public Task LoadProducts();
        public Task<Product> GetProduct(int id);
        public Task AddProduct(Product product);
        public Task DeleteProduct(int id);
    }
}
