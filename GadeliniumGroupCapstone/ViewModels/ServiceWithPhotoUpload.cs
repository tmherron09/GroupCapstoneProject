using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.ViewModels
{
    public class ServiceWithPhotoUpload
    {
        public Service Service { get; set; }
        public IFormFile UploadFile { get; set; }

        public ServiceWithPhotoUpload()
        {

        }
        public ServiceWithPhotoUpload(Service service)
        {
            Service = service;
        }
    }
}
