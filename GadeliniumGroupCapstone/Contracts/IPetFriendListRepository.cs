using GadeliniumGroupCapstone.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IPetFriendListRepository : IRepositoryBase<PetFriendList>
    {

        List<string> GetFriendsOnLine(List<string> onlinePets, string userId);

    }
}
