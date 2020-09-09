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

        public SitterRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
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
