using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class PetAccount : IAccount
    {

        public int PetAccountId { get; set; }
        public string Breed { get; set; }
        
        [DisplayName("Pet Name")]
        public string PetName { get; set; }
        public DateTime Dob { get; set; }
        [DisplayName("Animal Type")]
        public string AnimalType { get; set; }
        [DisplayName("Phone Number")]
        public string PetPhone { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("PhotoBin")]
        public int PhotoBinId { get; set; }
        public PhotoBin PetProfileImage { get; set; }


    }
}
