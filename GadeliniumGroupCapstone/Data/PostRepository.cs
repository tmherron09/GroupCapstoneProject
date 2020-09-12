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


    }
}
