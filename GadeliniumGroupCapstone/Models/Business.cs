﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class Business : IAccount
    {
        [Key]
        public int BusinessId { get; set; }

        public string BusinessName { get; set; }

        public string Address { get; set; }
        public string Zip { get; set; }
        public int Hours { get; set; }
        public string Phone { get; set; }

        [ForeignKey("PhotoBin")]
        public int PhotoBinId { get; set; }
        public PhotoBin BusinessLogo{ get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
