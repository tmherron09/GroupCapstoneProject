using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class Other
    {
        [Key]
        public int OtherId { get; set; }
        
        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public Business Business { get; set; }
    }
}
