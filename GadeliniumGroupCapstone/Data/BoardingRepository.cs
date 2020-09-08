using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class BoardingRepository : RepositoryBase<Boarding>, IBoardingRepository
    {

        public BoardingRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {

        }

        public void CreateBoarding(Boarding boarding)
        {
            throw new NotImplementedException();
        }

        public Test GetBoarding(int boardingId)
        {
            throw new NotImplementedException();
        }
    }
}
