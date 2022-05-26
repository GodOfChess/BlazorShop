using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services.LinkService
{
    public class LinkService : ILinkService
    {
        private readonly HttpClient _httpClient;

        public LinkService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Link>> LoadLinksByProduct(string productName)
        {
            return await _httpClient.GetFromJsonAsync<List<Link>>($"api/Link/{productName}");
        }

        public async Task<List<Link>> LoadLinks()
        {
            return await _httpClient.GetFromJsonAsync<List<Link>>($"api/Link");
        }

        public async Task PostLink(Link link)
        {
            await _httpClient.PostAsJsonAsync("api/Link", link);
        }

        public async Task DeleteLink(int id)
        {
            await _httpClient.DeleteAsync($"api/Link/{id}");
        }
    }
}
