using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IPetAccountRepository : IRepositoryBase<PetAccount>
    {
        PetAccount GetPetAccount(int petAccountId);
        void CreatePetAccount(PetAccount petAccount);
    }
}
