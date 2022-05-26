using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services.LinkService
{
    public interface ILinkService
    {
        Task<List<Link>> LoadLinksByProduct(string productName);
        Task<List<Link>> LoadLinks();
        Task PostLink(Link link);
        Task DeleteLink(int id);
    }
}
