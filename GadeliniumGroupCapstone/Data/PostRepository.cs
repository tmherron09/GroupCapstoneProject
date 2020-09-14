using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using GadeliniumGroupCapstone.NewsFeedService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {

        public PostRepository(PetAppDbContext petAppDbContext):base(petAppDbContext)
        {

        }

        public Post GetLastPostAdded() =>
            PetAppDbContext.Posts.OrderByDescending(p => p.PostId).FirstOrDefault();

        public List<Post> GetPostsForUser(string userId)
        {
            var postUsers = PetAppDbContext.PostUsers.Where(pu => pu.UserId == userId).Select(pu => pu.PostId);
            return FindAllByCondition(p => postUsers.Contains(p.PostId)).ToList();
        }

        
    }
}
