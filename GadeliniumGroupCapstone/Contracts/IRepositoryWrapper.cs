using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IRepositoryWrapper
    {
        ITestRepository Test { get; }

        void Save();
    }
}
