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

    }
}
