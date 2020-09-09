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

        public PetBioRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
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
