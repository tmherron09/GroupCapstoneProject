using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GadeliniumGroupCapstone.AuthorizationPolicies;
using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Data;
using GadeliniumGroupCapstone.Models;
using GadeliniumGroupCapstone.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GadeliniumGroupCapstone.Controllers
{
    public class BusinessController : Controller
    {
        private IRepositoryWrapper _repo;
        private IAuthorizationService _authorizationService;
        private UserManager<User> _userManager;

        public BusinessController(IRepositoryWrapper repo, IAuthorizationService authorizationService, UserManager<User> userManager)
        {
            _repo = repo;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }

        // GET: BusinessController
        [HttpGet]

        public IActionResult Index(int businessId)
        { 

            var business = _repo.Business.GetBusiness(businessId);

            BusinessInfoViewModel model = new BusinessInfoViewModel(business, _repo);


            return View("Info",model);
        }

        // GET: BusinessController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BusinessController/Create
        public async Task<IActionResult> Create(int businessId)
        {
            var business = _repo.Business.GetBusiness(businessId);

            //business.UserId = _userManager.GetUserId(User);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, business, new UserIdMatchRequirement());
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }


            return View();
        }

        // POST: BusinessController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        
        public IActionResult EditService(int id)
        {
            return View();
        }

        // POST: BusinessController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BusinessController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BusinessController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
