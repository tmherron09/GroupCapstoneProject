using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GadeliniumGroupCapstone.AuthorizationPolicies
{
    public class UserIdMatchRequirement : IAuthorizationRequirement
    {

        public UserIdMatchRequirement()
        {

        }


    }
}
