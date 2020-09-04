using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        [ForeignKey("Pet")]
        public int PetId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Business")]
        public int BusinessId { get; set; }
    }
}
