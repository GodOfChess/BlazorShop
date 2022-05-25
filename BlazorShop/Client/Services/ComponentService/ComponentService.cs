using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services.ComponentService
{
    public class ComponentService : IComponentService
    {
        private readonly HttpClient _httpClient;
        public List<Component> Components { get; set; } = new List<Component>();

        public ComponentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task LoadComponents()
        {
            Components = await _httpClient.GetFromJsonAsync<List<Component>>("api/Component");
        }

        public async Task AddComponent(Component component)
        {
            await _httpClient.PostAsJsonAsync("api/Component", component);
        }

        public async Task DeleteComponent(int id)
        {
            await _httpClient.DeleteAsync($"api/Component/{id}");
        }
    }
}
