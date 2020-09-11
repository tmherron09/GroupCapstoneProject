using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class PetBio
    {
        public int PetBioId { get; set; }
        [DisplayName("Pet Info/Description")]
        public string PetInfo { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string Hobbies { get; set; }

        [ForeignKey("PetAccount")]
        public int PetId { get; set; }
        [DisplayName("Pet Name")]
        public PetAccount PetAccount { get; set; }
    }
}
