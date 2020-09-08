using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface ISitterRepository : IRepositoryBase<Sitter>
    {
        Test GetSitter(int otherId);
        void CreateSitter(Sitter sitter);
    }
}
