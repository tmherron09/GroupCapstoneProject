using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class PetAccountRepository : RepositoryBase<PetAccount>, IPetAccountRepository
    {

        public PetAccountRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {

        }

        public void CreatePetAccount(PetAccount petAccount)
        {
            throw new NotImplementedException();
        }

        public PetAccount GetPetAccount(int petAccountId)
        {
            throw new NotImplementedException();
        }
    }
}
