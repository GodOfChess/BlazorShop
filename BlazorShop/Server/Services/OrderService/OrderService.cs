using BlazorShop.Shared.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public OrderService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ProductsConnection");
        }

        public async Task<List<Order>> GetOrders()
        {
            IEnumerable<Order> orders;
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    orders = await conn.QueryAsync<Order>("select * from orders");
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
            return orders.ToList();
        }

        public async Task PostOrder(Order order)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync($"insert into Orders(UserName, Price) values('{order.UserName}','{order.Price}')");
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
