using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Chat
{
    public class PetFriendList
    {
        [Key]
        public int PetFriendListId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string PetName { get; set; }
        public string FriendPetName { get; set; }

    }
}
