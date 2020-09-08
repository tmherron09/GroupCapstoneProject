using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class VetRepository : RepositoryBase<Vet>, IVetRepository
    {

        public VetRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {

        }

        public void CreateVet(Vet vet)
        {
            throw new NotImplementedException();
        }

        public Test GetVet(int vetId)
        {
            throw new NotImplementedException();
        }
    }
}
