using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class BlockedUsers
    {

        [Key]
        public int BlockedUserID { get; set; }
        
        [ForeignKey("PetAccount")]
        public int PetAccountId { get; set; }
        public PetAccount PetAccount { get; set; }


    }
}
