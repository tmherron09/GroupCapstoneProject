using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {

        public AccountRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext)
        {

        }

        public void CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Test GetAccount(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
