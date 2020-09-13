using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.NewsFeedService.Models
{
    public class Post
    {
        public int PostId { get; set; }
        // Can be the Id of either a PetAccount or BusinessAccount
        // Is not Foreign Key
        public int PosterId { get; set; }
        public string PosterName { get; set; }
        public PosterType PosterType { get; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        [ForeignKey("PhotoBin")]
        public int? PhotoBinId { get; set; }
        public PhotoBin PostImage { get; set; }
        [NotMapped]
        public List<string> Subscribers { get; set; }

    }

    public enum PosterType
    {
        BusinessPoster,
        PetPoster,
        AdminPoster,
        ServicePoster,
        AlertPoster
    }
}
