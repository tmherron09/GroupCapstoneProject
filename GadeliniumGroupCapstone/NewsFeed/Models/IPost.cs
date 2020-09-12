﻿using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.NewsFeedService.Models
{
    public interface IPost
    {
        public int PostId { get; set; }
        public int PosterId { get; set; }
        public string PosterName { get; set; }
        public PosterType PosterType { get; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public int? PhotoBinId { get; set; }
        public PhotoBin PostImage { get; set; }
        public int Likes { get; set; }

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
