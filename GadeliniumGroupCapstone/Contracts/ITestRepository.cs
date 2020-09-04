using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface ITestRepository : IRepositoryBase<Test>
    {
        Test GetTest(int testId);
        void CreateTest(Test test);
    }
}
