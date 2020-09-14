using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IBlockedUserRepository : IRepositoryBase<BlockedUsers>
    {
        BlockedUsers GetBlockedUserAccount(int blockedUserId);

        BlockedUsers GetBlockedUserId(int blockUserId);

        void CreateBlockUser(BlockedUsers blockedUsers);

        void UpdateBlockUser(BlockedUsers blockedUsers);

        void DeleteBlockUser(BlockedUsers blockedUsers);

        void Save();

    }
}
