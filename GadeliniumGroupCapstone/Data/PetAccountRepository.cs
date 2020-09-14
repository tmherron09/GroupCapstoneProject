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


        public PetAccountRepository(PetAppDbContext petAppDbContext):base(petAppDbContext)
        {

            }

            public void CreatePetAccount(PetAccount petAccount) => Create(petAccount);

            public PetAccount GetPetAccount(int petAccountId)
            {
                var petAccount = FindAllByCondition(p => p.PetAccountId.Equals(petAccountId)).SingleOrDefault();
                return petAccount;
            }

            public void UpdatePetAccount(PetAccount petAccount) => Update(petAccount);

            public void UpdatePetAccount(int petAccountId)
            {
                var petAccount = FindAllByCondition(p => p.PetAccountId.Equals(petAccountId)).SingleOrDefault();
                Update(petAccount);
            }


            public void DeletePetAccount(PetAccount petAccount) => Delete(petAccount);

            public void DeletePetAccount(int petAccountId)
            {
                var petAccount = GetPetAccount(petAccountId);
                Delete(petAccount);
            }

            public void Save()
            {
                PetAppDbContext.SaveChanges();
            }

        public List<PetAccount> GetPetAccountOfUserId(string userId) =>
            FindAllByCondition(p => p.UserId == userId).ToList();

        public List<PetAccount> SearchByName(string searchValue)
        {
            var results = FindAllByCondition(b => b.PetName.Contains(searchValue)).ToList();

            for (int i = 0; i < results.Count; i++)
            {
                results[i].PetProfileImage = PetAppDbContext.PhotoBins.Where(p => p.PhotoId == results[i].PhotoBinId).FirstOrDefault();
            }
                return results;
        }
        public int GetPetBioId(int petAccountId)
        {
            return PetAppDbContext.PetBios.Where(pb => pb.PetId == petAccountId).Select(pb=> pb.PetBioId).SingleOrDefault();
        }

        public List<string> GetUserPetNames(string userId) =>
            FindAllByCondition(p => p.UserId == userId).Select(p => p.PetName).ToList();

        public int GetPetAccountIdFromPetName(string petName) =>
            FindAllByCondition(pa => pa.PetName == petName).Select(pa => pa.PetAccountId).FirstOrDefault();
    }
}
