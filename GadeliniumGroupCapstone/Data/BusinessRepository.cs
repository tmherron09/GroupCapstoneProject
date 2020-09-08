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

        public BusinessRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {

        }

        public void CreateBusiness(Business business)
        {
            throw new NotImplementedException();
        }

        public Business GetBusiness(int businessId)
        {
            throw new NotImplementedException();
        }
    }
}
