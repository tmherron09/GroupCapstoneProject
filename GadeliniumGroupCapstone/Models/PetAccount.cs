using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class PetAccount
    {

        public int PetAccountId { get; set; }
        public string Breed { get; set; }
        public string Species { get; set; }
        public string PetName { get; set; }
        public DateTime Dob { get; set; }
        public string AnimalType { get; set; }
        public string PetPhone { get; set; }

        [ForeignKey(User)]
        public int UserId { get; set; }

        public User user { get; set; }


    }
}
