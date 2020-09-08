using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IOtherRepository : IRepositoryBase<Other>
    {
        Test GetOther(int otherId);
        void CreateOther(Other other);
    }
}
