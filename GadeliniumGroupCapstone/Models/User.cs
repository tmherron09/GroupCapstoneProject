using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
    
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}
