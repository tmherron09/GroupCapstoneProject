using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class FavoritePets
    {
        public int FavoritePetId { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }
        
        [ForeignKey("PetAccountId")]
        public int PetAccountId { get; set; }
        public PetAccount PetAccount { get; set; }

        public FavoritePets(string userId, int petAccountId)
        {
            UserId = userId;
            PetAccountId = petAccountId;
        }
    }
}
