using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }
        
        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public Business Business { get; set; }
    }
}
