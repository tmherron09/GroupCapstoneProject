using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class TestRepository : RepositoryBase<Test>, ITestRepository
    {

        public TestRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {

        }

        public void CreateTest(Test test)
        {
            throw new NotImplementedException();
        }

        public Test GetTest(int testId)
        {
            throw new NotImplementedException();
        }
    }
}
