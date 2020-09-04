using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class Groomer
    {
        public int GroomerId { get; set; }
        [ForeignKey("Business")]
        public int BusinessId { get; set; }

    }
}
