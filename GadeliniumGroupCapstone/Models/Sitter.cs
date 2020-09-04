using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class Sitter
    {
        public int SitterId { get; set; }
        [ForeignKey("Business")]
        public int BusinessId { get; set; }
    }
}
