using BlazorShop.Shared.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("ProductsConnection");
        }

        public async Task<bool> RegisterUser(User user)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                IEnumerable<User> users;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    users = await conn.QueryAsync<User>("select * from users");
                    foreach (var currentUser in users)
                    {
                        if (currentUser.UserName == user.UserName)
                        {
                            return false;
                        }
                    }
                    await conn.ExecuteAsync($"insert into Users(UserName, Pass) values('{user.UserName}','{user.Pass}')");
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
        public async Task<bool> LoginUser(User user)
        {
            IEnumerable<User> users;
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    users = await conn.QueryAsync<User>("select * from dbo.users");
                    foreach (var currentUser in users)
                    {
                        if (currentUser.UserName == user.UserName && currentUser.Pass == user.Pass)
                        {
                            return true;
                        }
                    }
                    return false;
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

        public async Task<bool> CheckAdmin(User user)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    user = await conn.QueryFirstOrDefaultAsync<User>($"select IsAdmin from users where UserName='{user.UserName}'");
                    if (user.IsAdmin)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public async Task<List<User>> GetAllUsers()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                IEnumerable<User> users;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    users = await conn.QueryAsync<User>("select * from users");
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
                return users.ToList();
            }
        }
    }
}
