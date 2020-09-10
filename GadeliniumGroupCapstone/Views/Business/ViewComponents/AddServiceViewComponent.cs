using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Views.Business.ViewComponents
{
    public class AddServiceViewComponent : ViewComponent
    {
        public Service service;

        public AddServiceViewComponent()
        {
            service = new Service();
        }

        public async Task<IViewComponentResult> InvokeAsync(int businessId)
        {
            service.BusinessId = businessId;
            return View(service);

        }

    }
}
