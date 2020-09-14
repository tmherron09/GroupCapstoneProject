using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.ViewModels
{
    public class PetWithImage
    {
        public PetAccount PetAccount { get; set; }
        public IFormFile UploadFile { get; set; }

        public PetWithImage()
        {

        }
        public PetWithImage(PetAccount petAccount)
        {
            PetAccount = petAccount;
        }
    }
}
