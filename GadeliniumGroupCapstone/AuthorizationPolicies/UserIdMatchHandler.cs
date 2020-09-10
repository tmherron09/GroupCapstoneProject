using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.AuthorizationPolicies
{
    public class UserIdMatchHandler : AuthorizationHandler<UserIdMatchRequirement, IAccount>
    {

        protected UserManager<User> _userManager;

        public UserIdMatchHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserIdMatchRequirement requirement, IAccount resource )
        {
            if(context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            if(resource.UserId == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
