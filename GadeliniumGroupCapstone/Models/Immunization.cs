using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class Immunization
    {
        [Key]
        public int ImmunizationId { get; set; }

        public string ImmunizationName { get; set; }

        public DateTime DateReceived { get; set; }

        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }
        public MedicalRecord medicalRecord { get; set; }


    }
}
