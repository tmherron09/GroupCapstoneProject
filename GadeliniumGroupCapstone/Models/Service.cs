using GadeliniumGroupCapstone.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceTag { get; set; }
        public string ServiceName { get; set; }
        public string ServiceTagLine { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceBannerUrl { get
            {
                if(ServiceTag != null)
                {
                    return ServicePhotoRef.GetServiceBannerUrl(ServiceTag);
                }
                return @"~\images\ServiceBanners\pet_store.png";
            }}
        public PhotoBin ServiceThumbnail { get; set; }
        public string ServiceFurtherDescription { get; set; }
        public int ServiceDisplayOrder { get; set; }


        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public Business Business { get; set; }


    }
}
