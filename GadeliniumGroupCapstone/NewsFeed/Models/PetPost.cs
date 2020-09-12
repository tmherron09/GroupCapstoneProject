using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.NewsFeedService.Models
{
    public class PetPost : IPost
    {
        public int PostId { get; set; }
        public int PosterId { get; set; }
        public string PosterName { get; set; }
        public PosterType PosterType
        {
            get
            {
                return PosterType.PetPoster;
            }
        }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public int? PhotoBinId { get; set; }
        public PhotoBin PostImage { get; set; }
        public int Likes { get; set; }

        public PetPost(PetAccount postingPet)
        {

        }

        public PetPost(PetAccount postingPet, IFormFile uploadFile)
        {

        }
    }
}
