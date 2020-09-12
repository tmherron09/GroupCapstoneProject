using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.NewsFeedService.Models
{
    public class PostUser
    {
        public string UserId { get; set; }
        public int PostId { get; set; }
        public bool IsLiked { get; set; }

    }
}
