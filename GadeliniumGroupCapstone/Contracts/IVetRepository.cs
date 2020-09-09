using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IVetRepository : IRepositoryBase<Vet>
    {
        Test GetVet(int vetId);
        void CreateVet(Vet vet);
    }
}
