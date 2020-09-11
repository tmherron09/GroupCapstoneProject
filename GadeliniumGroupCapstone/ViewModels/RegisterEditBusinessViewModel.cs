using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.ViewModels
{
    public class RegisterEditBusinessViewModel
    {
        public PhotoBin PhotoBin { get; set; }
        public Business Business { get; set; }
        public IFormFile UploadFile { get; set; }

        public RegisterEditBusinessViewModel(Business business)
        {
            PhotoBin = new PhotoBin();
            Business = business;
        }
        public RegisterEditBusinessViewModel()
        {
            PhotoBin = new PhotoBin();
        }

    }
}
