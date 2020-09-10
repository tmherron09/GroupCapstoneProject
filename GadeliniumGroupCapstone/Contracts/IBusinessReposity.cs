using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IBusinessRepository : IRepositoryBase<Business>
    {
        List<Business> GetAllBusinesses();
        Business GetBusiness(int businessId);
        void CreateBusiness(Business business);
        List<Business> SearchByName(string searchValue);
    }

}
