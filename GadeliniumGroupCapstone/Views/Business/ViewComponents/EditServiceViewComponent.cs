using GadeliniumGroupCapstone.Models;
using GadeliniumGroupCapstone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Views.Business.ViewComponents
{
    public class EditServiceViewComponent : ViewComponent
    {
        public ServiceWithPhotoUpload _service { get; set; }

        public EditServiceViewComponent()
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync(ServiceWithPhotoUpload service)
        {
            _service = service;
            return View(service);

        }
    }
}
