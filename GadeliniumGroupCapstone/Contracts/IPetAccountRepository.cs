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

        void UpdatePetAccount(PetAccount petAccount);

        void DeletePetAccount(PetAccount petAccount);

        List<PetAccount> GetPetAccountOfUserId(string userId);

        int GetPetBioId(int petAccountId);

        List<PetAccount> SearchByName(string searchValue);
        
        List<string> GetUserPetNames(string userId);
        int GetPetAccountIdFromPetName(string petName);


        void Save();
    }
}
