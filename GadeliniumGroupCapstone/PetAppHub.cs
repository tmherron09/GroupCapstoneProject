using GadeliniumGroupCapstone.Chat;
using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Data;
using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Identity;
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
        private UserManager<User> _userManager;
        private PetAppDbContext _context;
        public PetAppHub(IRepositoryWrapper repo, UserManager<User> userManager, PetAppDbContext petAppDbContext)
        {
            _repo = repo;
            _userManager = userManager;
            _context = petAppDbContext;
        }

        // User/Group Management

        public async Task SetupUserInChatOnConnect(string chatName)
        {
            if(!ChatService.ConnectedUsers.ContainsValue("chatName"))
            {
                ChatService.ConnectedUsers.Add(Context.ConnectionId, chatName);
            }

            var userId = Context.UserIdentifier;

            List<string> onlinePets = ChatService.ConnectedUsers.Values.ToList();

            var friendsList = _repo.PetFriendList.GetFriendsOnLine(onlinePets, userId);
            var businessFav = _repo.FavoriteBusiness.GetUserFavoriteBusinessesNames(userId);
            if(businessFav.Count() > 0)
            {
                foreach(var bus in businessFav)
                {
                    friendsList.Add(bus);
                }
            }


            if(friendsList.Count() > 0)
            {
                foreach(var friend in friendsList)
                {
                    var friendConnectionId = ChatService.ConnectedUsers.Where(d => d.Value == friend).Select(d => d.Key).First();
                    Clients.Client(friendConnectionId).SendAsync("AddFriend", chatName);
                }
            }

            await Clients.Caller.SendAsync("RecieveFriendList", friendsList);
        }


        public async Task SendMessage(string selectedFriend, string message, string chatName)
        {
            List<string> messageHistory = new List<string>();
            var friendConnectionId = ChatService.ConnectedUsers.Where(d => d.Value == selectedFriend).Select(d => d.Key).First();
            string outgoingMessage = $"{chatName}: {message}";
            messageHistory.Add(outgoingMessage);
            var friendName = chatName;
            await Clients.Caller.SendAsync("RecieveFriendMessageHistory", messageHistory, friendName);
            friendName = selectedFriend;
            await Clients.Client(friendConnectionId).SendAsync("RecieveFriendMessageHistory", messageHistory, chatName);

        }





        public override Task OnDisconnectedAsync(Exception ex)
        {
            ChatService.ConnectedUsers.Remove(Context.ConnectionId);
            return Task.CompletedTask;
        }



        public async Task SendPetList(string searchValue)
        {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<PetAccount> pets = _repo.PetAccount.SearchByName(searchValue);
            for(int i = 0; i < pets.Count; i++)
            {
                pets[i].IsFavorited = _repo.FavoriteBusiness.IsFavorited(userId, pets[i].PetAccountId);
            }


            await Clients.Caller.SendAsync("RecievePetList", pets);

        }

        // Business Search Methods

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
