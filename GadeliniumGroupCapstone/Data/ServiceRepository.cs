using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {

        public ServiceRepository(PetAppDbContext petAppDbContext):base(petAppDbContext)
        {

        }

        public void CreateService(Service service)
        {
            throw new NotImplementedException();
        }

        public List<Service> GetBusinessServices(int businessId) =>
            FindAllByCondition(s => s.BusinessId == businessId).ToList();

        public Service GetService(int serviceId) =>
            FindAllByCondition(s => s.ServiceId == serviceId).Single();

        public int LastServiceAddedId() =>
            PetAppDbContext.Services.OrderByDescending(p => p.ServiceId).Select(p => p.ServiceId).FirstOrDefault();
    }
}
