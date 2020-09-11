using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IPetBioRepository : IRepositoryBase<PetBio>
    {

        PetBio GetPetBioAccount(int petBioId);
        PetBio GetPetBio(int petBioId);
        void CreatePetBio(PetBio petBio);

        void UpdatePetBio(int petBioId);

        void DeletePetBio(PetBio petBio);

        PetAccount GetAssociatedPet(int petBioId);

    }
}
