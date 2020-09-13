using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IServiceRepository : IRepositoryBase<Service>
    {
        Service GetService(int serviceId);
        void CreateService(Service service);
        List<Service> GetBusinessServices(int businessId);
        List<Service> SearchByName(string searchValue);
        int LastServiceAddedId();
        List<Service> SearchByTag(string searchValue);
        
    }
}
