using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        // Purposely Ommitting User object, Seperation of address/user except when explicitly called.
        // This address is seperate from Business Address, as it is of an individual user and holds personal data
        // Business Addresses are public, hence stored elsewhere.

        [ProtectedPersonalData]
        public string StreetAddress { get; set; }
        [ProtectedPersonalData]
        public string City { get; set; }
        [ProtectedPersonalData]
        public string State { get; set; }
        [ProtectedPersonalData]
        public string ZipCode { get; set; }
    }
}
