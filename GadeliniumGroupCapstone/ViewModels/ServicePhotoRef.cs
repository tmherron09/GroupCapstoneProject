using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.ViewModels
{
    public static class ServicePhotoRef
    {

        public static string GetServiceBannerUrl(string serviceTag)
        {
            switch(serviceTag)
            {
                default: return @"~\images\ServiceBanners\pet_store.png";
            }
        }


    }
}
