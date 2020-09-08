using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface ITrainerRepository : IRepositoryBase<Trainer>
    {
        Test GetTrainer(int trainerId);
        void CreateTrainer(Trainer trainer);
    }
}
