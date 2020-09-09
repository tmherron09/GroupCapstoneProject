using GadeliniumGroupCapstone.Contracts;
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

        public void CreatePetBio(PetBio petBio)
        {
            throw new NotImplementedException();
        }

        public Test GetPetBio(int petBioId)
        {
            throw new NotImplementedException();
        }
    }
}
