using BlazorShop.Shared.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ProductsConnection");
        }

        public async Task<List<Product>> GetAllProducts()
        {
            IEnumerable<Product> products;
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    products = await conn.QueryAsync<Product>("select * from products");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return products.ToList();
        }

        public async Task<Product> GetProduct(int id)
        {
            Product product = new Product();

            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    product = await conn.QueryFirstOrDefaultAsync<Product>($"select * from products where id = {id}");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return product;
        }

        public async Task<bool> AddProduct(Product product)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync($"insert into Products(Title, Info, Img, Price) values('{product.Title}','{product.Info}','{product.Img}','{product.Price}')");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
                return true;
            }
        } 

        public async Task DeleteProduct(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync($"delete from products where id = {id}");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }
    }
}
