using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class FavoriteBusinessRepository : RepositoryBase<FavoriteBusiness>, IFavoriteBusinessRepository
    {

        public FavoriteBusinessRepository(PetAppDbContext petAppDbContext) : base(petAppDbContext)
        {

        }

        public void CreateFavoriteBusinessEntry(string userId, int businessId)
        {
            FavoriteBusiness fb = new FavoriteBusiness(userId, businessId);
            Create(fb);
            
        }

        public FavoriteBusiness GetFavoriteBusinessEntry(string userId, int businessId) =>
            FindAllByCondition(fb => fb.UserId == userId && fb.BusinessId == businessId).FirstOrDefault();

        public List<string> GetUserIdsThatLikeBusiness(int businessId) =>
            FindAllByCondition(fb => fb.BusinessId == businessId).Select(fb => fb.UserId).ToList();
        

        public List<Business> GetUserFavoriteBusinesses(string userId) =>
            FindAllByCondition(fb => fb.UserId == userId).Select(fb => fb.Business).ToList();
        public List<string> GetUserFavoriteBusinessesNames(string userId) {
            var favBus = FindAllByCondition(fb => fb.UserId == userId).Select(fb=>fb.BusinessId).ToList();
            return PetAppDbContext.Businesses.Where(b => favBus.Contains(b.BusinessId)).Select(b => b.BusinessName).ToList();
        }

        public bool IsFavorited(string userId, int businessId)
        {
            return PetAppDbContext.FavoriteBusinesses.Any(fb => fb.UserId == userId && fb.BusinessId == businessId);
        }
    }
}
