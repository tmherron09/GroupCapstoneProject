using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class TrainerRepository : RepositoryBase<Trainer>, ITrainerRepository
    {

        public TrainerRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {

        }

        public void CreateTrainer(Trainer trainer)
        {
            throw new NotImplementedException();
        }

        public Test GetTrainer(int trainerId)
        {
            throw new NotImplementedException();
        }
    }
}
