using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IServiceRepository : IRepositoryBase<Service>
    {
        Test GetService(int otherId);
        void CreateService(Sitter sitter);
        List<Service> GetBusinessServices(int businessId);
    }
}
