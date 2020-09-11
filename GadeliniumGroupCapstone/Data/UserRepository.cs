using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {

        public UserRepository(PetAppDbContext petAppDbContext) : base(petAppDbContext)
        {

        }

        public void CreateUser(User siteUser)
        {
            throw new NotImplementedException();
        }

        public Test GetUser(int siteUserId)
        {
            throw new NotImplementedException();
        }
    }
}
