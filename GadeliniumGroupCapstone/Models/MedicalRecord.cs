using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class MedicalRecord
    {
        [Key]
        public int MedicalRecordId { get; set; }



        [ForeignKey("PetAccount")]
        public int PetId { get; set; }
        public PetAccount PetAccount { get; set; }
    }
}
