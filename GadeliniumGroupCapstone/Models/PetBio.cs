using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class PetBio
    {
        public int PetBioId { get; set; }
        public string PetInfo { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string Hobbies { get; set; }

        [ForeignKey("PetAccount")]

        public int PetId { get; set; }

        public PetAccount PetAccount { get; set; }





    }
}
