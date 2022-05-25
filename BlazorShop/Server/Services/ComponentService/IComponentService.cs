using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Services.ComponentService
{
    public interface IComponentService
    {
        Task<List<Component>> GetComponents();
        Task PostComponent(Component component);
        Task DeleteComponent(int id);
    }
}
