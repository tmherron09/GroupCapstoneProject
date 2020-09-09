using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class SitterRepository : RepositoryBase<Sitter>, ISitterRepository
    {

        public SitterRepository(PetAppDbContext petAppDbContext):base(petAppDbContext)
        {

        }

        public void CreateSitter(Sitter sitter)
        {
            throw new NotImplementedException();
        }

        public Test GetSitter(int otherId)
        {
            throw new NotImplementedException();
        }
    }
}
