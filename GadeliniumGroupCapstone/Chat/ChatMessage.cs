using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Chat
{
    public class ChatMessage
    {
        [Key]
        public int ChatMessageId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User{ get; set; }
        public string FriendName { get; set; }
        public string Message { get; set; }

    }
}
