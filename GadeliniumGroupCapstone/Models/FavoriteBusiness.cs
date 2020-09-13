using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class FavoriteBusiness
    {
        public int FavoriteBusinessId { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("BusinessId")]
        public int BusinessId { get; set; }
        public Business Business { get; set; }

        public FavoriteBusiness(string userId, int businessId)
        {
            UserId = userId;
            BusinessId = businessId;
        }
    }
}
