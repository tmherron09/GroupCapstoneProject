using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.ViewModels
{
    public class BusinessInfoViewModel
    {

        public Business Business{ get; set; }
        public List<Service> Services { get; set; }


        public BusinessInfoViewModel(Business business, IRepositoryWrapper _repo)
        {
            Business = business;
            Services = _repo.Service.GetBusinessServices(business.BusinessId);
            if(Services.Count > 0)
            {
                for(int i = 0; i < Services.Count; i++)
                {
                    Services[i].ServiceThumbnail = _repo.PhotoBin.GetPhoto(Services[i].PhotoBinId);
                }
            }
            Business.BusinessLogo = _repo.PhotoBin.GetPhoto(business.PhotoBinId);
        }

    }
}
