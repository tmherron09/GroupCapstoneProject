using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IGroomerRepository : IRepositoryBase<Groomer>
    {
        Test GetGroomer(int groomerId);
        void CreateGroomer(Groomer groomer);
    }
}
