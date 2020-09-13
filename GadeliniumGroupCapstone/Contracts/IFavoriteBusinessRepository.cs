using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IFavoriteBusinessRepository : IRepositoryBase<FavoriteBusiness>
    {
        List<Business> GetUserFavoriteBusinesses(string userId);
        void CreateFavoriteBusinessEntry(string userId, int businessId);
        FavoriteBusiness GetFavoriteBusinessEntry(string userId, int businessId);
        bool IsFavorited(string userId, int businessId);
        List<string> GetUserIdsThatLikeBusiness(int businessId);
    }
}
