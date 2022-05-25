using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services.ComponentService
{
    public interface IComponentService
    {
        List<Component> Components { get; set; }
        public Task LoadComponents();
        public Task AddComponent(Component component);
        public Task DeleteComponent(int id);
    }
}
