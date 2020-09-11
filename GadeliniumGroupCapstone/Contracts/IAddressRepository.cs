using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IBoardingRepository : IRepositoryBase<Boarding>
    {
        Test GetBoarding(int boardingId);
        void CreateBoarding(Boarding boarding);
    }
}
