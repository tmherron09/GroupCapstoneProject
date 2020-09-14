using GadeliniumGroupCapstone.Chat;
using GadeliniumGroupCapstone.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class PetFriendListRepository : RepositoryBase<PetFriendList>, IPetFriendListRepository
    {

        public PetFriendListRepository(PetAppDbContext petAppDbContext) : base(petAppDbContext)
        {

        }

        public List<string> GetFriendsOnLine(List<string> onlinePets, string userId) => FindAllByCondition(f => f.UserId == userId).Where(f=> onlinePets.Contains(f.FriendPetName)).Select(f=> f.FriendPetName).ToList();

    }
}
