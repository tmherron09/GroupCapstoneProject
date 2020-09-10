using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Business> businesses = _repo.Business.SearchByName(searchValue);

            await Clients.Caller.SendAsync("RecieveBusinessList", businesses);

        }

    }
}
