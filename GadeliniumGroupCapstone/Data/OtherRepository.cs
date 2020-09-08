using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class OtherRepository : RepositoryBase<Other>, IOtherRepository
    {

        public OtherRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {

        }

        public void CreateOther(Other other)
        {
            throw new NotImplementedException();
        }

        public Test GetOther(int otherId)
        {
            throw new NotImplementedException();
        }
    }
}
