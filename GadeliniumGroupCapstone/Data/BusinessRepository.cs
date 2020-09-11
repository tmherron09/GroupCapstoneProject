using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class BusinessRepository : RepositoryBase<Business>, IBusinessRepository
    {

        public BusinessRepository(PetAppDbContext petAppDbContext):base(petAppDbContext)
        {

        }

        public List<Business> GetAllBusinesses() =>
            FindAll().ToList();

        public void CreateBusiness(Business business)
        {
            throw new NotImplementedException();
        }

        public Business GetBusiness(int businessId) =>
            FindAllByCondition(b => b.BusinessId == businessId).SingleOrDefault();


        public List<Business> SearchByName(string searchValue)
        {
            var results = FindAllByCondition(b => b.BusinessName.Contains(searchValue)).ToList();

            for (int i = 0; i < results.Count; i++)
            {
                results[i].BusinessLogo = PetAppDbContext.PhotoBins.Where(p => p.PhotoId == results[i].PhotoBinId).SingleOrDefault();
            }

                return results;
        }

        public List<Business> SearchForServices(string searchValue)
        {
            var results = FindAllByCondition(b => b.BusinessName.Contains(searchValue)).ToList();

            for (int i = 0; i < results.Count; i++)
            {
                results[i].Services = PetAppDbContext.Services.Where(s => s.BusinessId == results[i].BusinessId).ToList();
            }

            return results;
        }

    }
}
