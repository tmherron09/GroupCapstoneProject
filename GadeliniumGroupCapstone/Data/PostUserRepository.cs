using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using GadeliniumGroupCapstone.NewsFeedService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class PostUserRepository : RepositoryBase<PostUser>, IPostUserRepository
    {

        public PostUserRepository(PetAppDbContext petAppDbContext):base(petAppDbContext)
        {

        }

        public PostUser GetPostUserEntry(string userId, int postId) =>
            FindAllByCondition(pu => pu.UserId == userId && pu.PostId == postId).FirstOrDefault();

        public bool HasUserLikedPost(int postId, string userId) =>
            FindAllByCondition(p => p.PostId == postId && p.UserId == userId).Select(p => p.IsLiked).FirstOrDefault();
    }
}
