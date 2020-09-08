using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        Test GetAccount(int accountId);
        void CreateAccount(Account account);
    }
}
