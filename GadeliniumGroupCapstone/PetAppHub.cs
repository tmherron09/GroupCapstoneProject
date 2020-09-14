using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone
{
    public class PetAppHub : Hub
    {
        private IRepositoryWrapper _repo;
        public PetAppHub(IRepositoryWrapper repo)
        {
            _repo = repo;
        }

        public async Task SendBusinessList(string searchValue)
        {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Business> businesses = _repo.Business.SearchByName(searchValue);
            for(int i = 0; i < businesses.Count; i++)
            {
                businesses[i].IsFavorited = _repo.FavoriteBusiness.IsFavorited(userId, businesses[i].BusinessId);
            }


            await Clients.Caller.SendAsync("RecieveBusinessList", businesses);

        }

        public async Task SendServiceList(string searchValue)
        {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Service> services = _repo.Service.SearchByName(searchValue);
            for (int i = 0; i < services.Count; i++)
            {
                services[i].Business.IsFavorited = _repo.FavoriteBusiness.IsFavorited(userId, services[i].Business.BusinessId);
            }
            await Clients.Caller.SendAsync("RecieveServiceList", services);
        }

        public async Task SendServiceTagList(string searchValue)
        {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Service> services = _repo.Service.SearchByTag(searchValue);
            for (int i = 0; i < services.Count; i++)
            {
                services[i].Business.IsFavorited = _repo.FavoriteBusiness.IsFavorited(userId, services[i].Business.BusinessId);
            }
            await Clients.Caller.SendAsync("RecieveServiceTagList", services);
        }


        // Currently just makes and deletes table entries. Later switch to true false.
        public async Task AddRemoveBusinessToFavorites(int businessId)
        {
            string message;
            bool isFavorited;
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if(_repo.FavoriteBusiness.IsFavorited(userId, businessId))
            {
                FavoriteBusiness favBus = _repo.FavoriteBusiness.GetFavoriteBusinessEntry(userId, businessId);
                _repo.FavoriteBusiness.Delete(favBus);
                _repo.Save();
                message = "Business Unfavorited.";
                isFavorited = false;
            }
            else
            {
                _repo.FavoriteBusiness.CreateFavoriteBusinessEntry(userId, businessId);
                _repo.Save();
                message = "Business Favorited.";
                isFavorited = true;
            }

            await Clients.Caller.SendAsync("FavoriteMessage", new { businessId, message, isFavorited });
        }

    }
}
