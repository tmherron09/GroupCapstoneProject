using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GadeliniumGroupCapstone.NewsFeedService
{
    public class NewsfeedService
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public NewsfeedService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task GetUserNewsfeed()
        {



            return;
        }

    }
}
