using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class Medication
    {
        [Key]
        public int MedicationId { get; set; }

        public string MedicationName { get; set; }

        public string Instructions { get; set; } // General statement/note of how often pet recieves dose.

        [ForeignKey("MedicalRecord")]
        public int MedicalRecordId { get; set; }
        public MedicalRecord medicalRecord { get; set; }

    }
}
