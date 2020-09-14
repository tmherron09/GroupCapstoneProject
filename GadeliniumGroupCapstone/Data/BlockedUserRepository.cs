using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class BlockedUserRepository : RepositoryBase<BlockedUsers>, IBlockedUserRepository
    {

        public BlockedUserRepository(PetAppDbContext petAppDbContext) : base(petAppDbContext)
        {

        }

        public void CreateBlockUser(BlockedUsers blockedUsers) => Create(blockedUsers);

        public void DeleteBlockUser(BlockedUsers blockedUsers)
        {
            Delete(blockedUsers);
        }

        public BlockedUsers GetBlockedUserAccount(int blockedUserId)
        {
            var blockUser = FindAllByCondition(b => b.BlockedUserID.Equals(blockedUserId)).SingleOrDefault();
            return blockUser;
        }

        public BlockedUsers GetBlockedUserId(int blockUserId)
        {
            var blockUser = FindAllByCondition(b => b.BlockedUserID == blockUserId).SingleOrDefault();
            return blockUser;
        }

        public void Save()
        {
            PetAppDbContext.SaveChanges();
        }

        public void UpdateBlockUser(BlockedUsers blockedUsers)
        {
            var blockUser = FindAllByCondition(b => b.BlockedUserID.Equals(blockedUsers)).SingleOrDefault();
            Update(blockUser);
        }
    }
}
