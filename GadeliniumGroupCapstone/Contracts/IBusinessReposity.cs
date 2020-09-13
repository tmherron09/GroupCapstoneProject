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
        Business GetBusinessOfUserId(string userId);
        void CreateBusiness(Business business);
        List<Business> SearchByName(string searchValue);
        bool UserHasBusiness(string userId);
        PhotoBin GetBusinessLogo(string businessName);
        Business GetBusinessByName(string businessName);
        string GetBusinessNameByUserId(string userId);
    }

}
