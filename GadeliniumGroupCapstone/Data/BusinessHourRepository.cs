using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class BusinessHourRepository : RepositoryBase<BusinessHour>, IBusinessHourRepository
    {

        public BusinessHourRepository(PetAppDbContext petAppDbContext):base(petAppDbContext)
        {

        }

        public void CreateBusinessHour(BusinessHour businessHour)
        {
            throw new NotImplementedException();
        }


        public BusinessHour GetBusinessHour(int businessHourId) =>
            FindAllByCondition(b => b.BusinessHourId == businessHourId).Single();
    }
}
