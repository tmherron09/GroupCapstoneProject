﻿using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class PetBioRepository : RepositoryBase<PetBio>, IPetBioRepository
    {

        public PetBioRepository(PetAppDbContext petAppDbContext):base(petAppDbContext)
        {
            
        }

        public void CreatePetBio(PetBio petBio) => Create(petBio);

        public void DeletePetBio(PetBio petBio)
        {
            throw new NotImplementedException();
        }

        public PetAccount GetAssociatedPet(int petBioId)
        {
            var petBio = FindAllByCondition(p => p.PetBioId == petBioId).Single();

            var pet = PetAppDbContext.PetAccounts.Where(pa => pa.PetAccountId == petBio.PetId).Single();
            return pet;

        }

        public PetBio GetPetBio(int petBioId)
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
