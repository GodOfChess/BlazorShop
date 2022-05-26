using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Services.LinkService
{
    public interface ILinkService
    {
        Task<List<Link>> GetLinksByProduct(string productName);
        Task<List<Link>> GetLinks();
        Task PostLink(Link link);
        Task DeleteLink(int id);
    }
}
