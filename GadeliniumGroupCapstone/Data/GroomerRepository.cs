using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class GroomerRepository : RepositoryBase<Groomer>, IGroomerRepository
    {

        public GroomerRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {

        }

        public void CreateGroomer(Groomer groomer)
        {
            throw new NotImplementedException();
        }

        public Test GetGroomer(int groomerId)
        {
            throw new NotImplementedException();
        }
    }
}
