using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IBusinessHourRepository : IRepositoryBase<BusinessHour>
    {
        BusinessHour GetBusinessHour(int businessHourId);
        void CreateBusinessHour(BusinessHour businessHour);

    }

}
