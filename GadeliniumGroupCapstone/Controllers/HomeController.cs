using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GadeliniumGroupCapstone.Models;
using GadeliniumGroupCapstone.Contracts;
using Microsoft.AspNetCore.Identity;

namespace GadeliniumGroupCapstone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepositoryWrapper _repo;
        private SignInManager<User> _signInManager;

        public HomeController(ILogger<HomeController> logger, IRepositoryWrapper repo, SignInManager<User> signInManager)
        {
            _logger = logger;
            _repo = repo;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            Console.WriteLine(User);

            if(User.IsInRole("Business Owner") && _signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Home", "Business");
            }
            else if (User.IsInRole("Pet Owner") && _signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Home", "PetAccounts");
            }


            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
