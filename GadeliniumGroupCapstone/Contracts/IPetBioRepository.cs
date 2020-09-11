using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IPetBioRepository : IRepositoryBase<PetBio>
    {
        Test GetPetBio(int petBioId);
        void CreatePetBio(PetBio petBio);

        void UpdatePetBio(int petBioId);

        void DeletePetBio(PetBio petBio);

    }
}
