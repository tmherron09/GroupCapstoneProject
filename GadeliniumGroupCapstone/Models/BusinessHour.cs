using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class BusinessHour
    {
        public int BusinessHourId { get; set; }
        [Required]
        public bool IsOpenMonday { get; set; }
        [Range(1,12)]
        public int MondayOpening { get; set; }
        [Range(1, 12)]
        public int MondayClosing { get; set; }

        [Required]
        public bool IsOpenTuesday { get; set; }
        [Range(1, 12)]
        public int TuesdayOpening { get; set; }
        [Range(1, 12)]
        public int TuesdayClosing { get; set; }

        [Required]
        public bool IsOpenWednesday { get; set; }
        [Range(1, 12)]
        public int WednesdayOpening { get; set; }
        [Range(1, 12)]
        public int WednesdayClosing { get; set; }

        [Required]
        public bool IsOpenThursday { get; set; }
        [Range(1, 12)]
        public int ThursdayOpening { get; set; }
        [Range(1, 12)]
        public int ThursdayClosing { get; set; }

        [Required]
        public bool IsOpenFriday { get; set; }
        [Range(1, 12)]
        public int FridayOpening { get; set; }
        [Range(1, 12)]
        public int FridayClosing { get; set; }

        [Required]
        public bool IsOpenSaturday { get; set; }
        [Range(1, 12)]
        public int SaturdayOpening { get; set; }
        [Range(1, 12)]
        public int SaturdayClosing { get; set; }

        [Required]
        public bool IsOpenSunday { get; set; }
        [Range(1, 12)]
        public int SundayOpening { get; set; }
        [Range(1, 12)]
        public int SundayClosing { get; set; }


    }
}
