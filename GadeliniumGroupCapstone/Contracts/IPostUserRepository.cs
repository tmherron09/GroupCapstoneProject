using GadeliniumGroupCapstone.Models;
using GadeliniumGroupCapstone.NewsFeedService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IPostUserRepository : IRepositoryBase<PostUser>
    {

        PostUser GetPostUserEntry(string userId, int postId);

        bool HasUserLikedPost(int postId, string userId);

    }
}
