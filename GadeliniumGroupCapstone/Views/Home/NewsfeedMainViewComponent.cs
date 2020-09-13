using GadeliniumGroupCapstone.NewsFeedService.Models;
using GadeliniumGroupCapstone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.Views.Home
{
    public class NewsfeedMainViewComponent : ViewComponent
    {


        public NewsfeedMainViewComponent()
        {

        }



        public async Task<IViewComponentResult> InvokeAsync()
        {

            PostViewModel postViewModel = new PostViewModel();

            return View(postViewModel);

        }

    }

    
}
