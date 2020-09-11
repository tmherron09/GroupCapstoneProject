using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class PetBioRepository : RepositoryBase<PetBio>, IPetBioRepository
    {

        public PetBioRepository(PetAppDbContext petAppDbContext) : base(petAppDbContext)
        {

        }

        public void CreatePetBio(PetBio petBio) => Create(petBio);

        public void DeletePetBio(PetBio petBio)
        {
            Delete(petBio);
        }


        public PetAccount GetAssociatedPet(int petBioId)
        {
            var petBio = FindAllByCondition(p => p.PetBioId == petBioId).SingleOrDefault();
            var petAccount = PetAppDbContext.PetAccounts.Where(p => p.PetAccountId == petBioId).SingleOrDefault();

            return petAccount;

        }


        public PetBio GetPetBioAccount(int petBioId)
        {
            var petBio = FindAllByCondition(p => p.PetBioId.Equals(petBioId)).SingleOrDefault();
            return petBio;
        }

        public void Save()
        {
            PetAppDbContext.SaveChanges();
        }

        public void UpdatePetBio(int petBioId)
        {

            var petBio = FindAllByCondition(p => p.PetBioId.Equals(petBioId)).SingleOrDefault();
            Update(petBio);
        }

    }
}

