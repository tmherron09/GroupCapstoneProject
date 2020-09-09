using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public interface IAccount
    {
        public string UserId { get; set; }
        public User User{ get; set; }
    }
}
