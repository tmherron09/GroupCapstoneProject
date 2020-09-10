using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IRepositoryWrapper
    {
        ITestRepository Test { get; }
        IAddressRepository Address { get; }
        IBoardingRepository Boarding { get; }
        IBusinessRepository Business { get; }
        IGroomerRepository Groomer { get; }
        IMedicalRecordRepository MedicalRecord { get; }
        IOtherRepository Other { get; }
        IPetAccountRepository PetAccount { get; }
        IPhotoBinRepository PhotoBin { get; }
        IUserRepository User { get; }
        IServiceRepository Service { get; }
        ISitterRepository Sitter { get; }
        ITrainerRepository Trainer { get; }
        IVetRepository Vet { get; }



        void Save();
    }
}
