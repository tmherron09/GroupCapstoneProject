using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class Boarding
    {
        [Key]
        public int BoardingId { get; set; }

        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public Business Business { get; set; }
    }
}
