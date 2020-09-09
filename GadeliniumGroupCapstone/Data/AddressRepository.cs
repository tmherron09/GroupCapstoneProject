using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Data
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {

        public AddressRepository(PetAppDbContext petAppDbContext):base(petAppDbContext)
        {

        }

        public void CreateAddress(Address boarding)
        {
            throw new NotImplementedException();
        }

        public Address GetAddress(int addressId)
        {
            throw new NotImplementedException();
        }

        public Address GetBusinessAddress(int businessId)
        {
            throw new NotImplementedException();
        }

        public Address GetUserAddress(int useId)
        {
            throw new NotImplementedException();
        }
    }
}
