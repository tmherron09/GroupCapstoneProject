using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Contracts
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {
        Address GetAddress(int addressId);
        Address GetBusinessAddress(int businessId);
        Address GetUserAddress(int useId);
        void CreateAddress(Address boarding);
    }
}
