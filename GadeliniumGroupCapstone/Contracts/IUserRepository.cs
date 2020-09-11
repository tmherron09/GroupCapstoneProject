using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Test GetUser(int siteUserId);
        void CreateUser(User siteUser);
    }
}
