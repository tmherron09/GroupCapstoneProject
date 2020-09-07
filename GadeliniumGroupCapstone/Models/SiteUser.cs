using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class SiteUser : IdentityUser
    {

        // Currently overrides but with no additional values. Placeholder should we need to store external API or other
        // User Sensitive information, we can store a reference or possibly Secret refs.
        // Other examples would be as we leave room to expand our Authorization Policies, making certain checked values here
        // Finding a way to pass it to "User" 

        // Example extension: Backup Email/ Secondary Email- Currently will become NULL, but will demonstrate visibility in Database of Custom IdentityUser
        [ProtectedPersonalData]
        [EmailAddress]
        public string SecondaryEmail { get; set; }
        public string NormalizedSecondaryEmail { get; set; }
        [ProtectedPersonalData]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool HasPet { get; set; }
        public bool HasMultiplePet { get; set; }
        public bool HasBusiness { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }

    }
}
