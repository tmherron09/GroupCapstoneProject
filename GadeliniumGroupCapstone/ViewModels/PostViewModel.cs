using GadeliniumGroupCapstone.NewsFeedService.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.ViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public IFormFile UploadFile { get; set; }
        public bool IsBusiness { get; set; }
        public List<string> PetNames { get; set; }
    }
}
