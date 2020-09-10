using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
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
            var items = FindAllByCondition(b => b.BusinessName.Contains(searchValue)).ToList();
            return items;
        }
    }
}
