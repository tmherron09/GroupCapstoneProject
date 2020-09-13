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

        public List<Service> SearchByName(string searchValue)
        {
            var results = FindAllByCondition(b => b.ServiceName.Contains(searchValue)).ToList();

            for (int i = 0; i < results.Count; i++)
            {
                results[i].ServiceThumbnail = PetAppDbContext.PhotoBins.Where(p => p.PhotoId == results[i].PhotoBinId).FirstOrDefault();
                results[i].Business = PetAppDbContext.Businesses.Where(b => b.BusinessId == results[i].BusinessId).FirstOrDefault();
            }

            return results;
        }

        public List<Service> SearchByTag(string searchValue)
        {
            var results = FindAllByCondition(b => b.ServiceTag.Contains(searchValue)).ToList();

            for (int i = 0; i < results.Count; i++)
            {
                results[i].ServiceThumbnail = PetAppDbContext.PhotoBins.Where(p => p.PhotoId == results[i].PhotoBinId).FirstOrDefault();
                results[i].Business = PetAppDbContext.Businesses.Where(b => b.BusinessId == results[i].BusinessId).FirstOrDefault();
            }

            return results;
        }
    }
}
