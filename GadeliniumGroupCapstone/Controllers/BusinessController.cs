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
        [Route("{controller}")]
        [Route("{controller}/Home")]
        public IActionResult Home()
        {
            var userdId = _userManager.GetUserId(User);

            var business = _repo.Business.GetBusinessOfUserId(userdId);

            if (business == null)
            {
                return RedirectToAction("SearchBusinesses", "Business");
            }

            BusinessInfoViewModel model = new BusinessInfoViewModel(business, _repo);

            return View("Info", model);
        }


        // GET: BusinessController
        [Route("{controller}/{businessId}")]
        [Route("{controller}/info/{businessId}")]
        public IActionResult Info(int businessId)
        {

            var business = _repo.Business.GetBusiness(businessId);

            BusinessInfoViewModel model = new BusinessInfoViewModel(business, _repo);


            return View("Info", model);
        }

        public IActionResult SearchBusinesses()
        {

            return View();

        }

        // GET: BusinessController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BusinessController/Create
        [HttpGet("{controller}/AddService/{businessId}")]
        public async Task<IActionResult> AddService(int? businessId)
        {
            if (businessId == null)
            {
                return View("Home", "Business");
            }

            var business = _repo.Business.GetBusiness((int)businessId);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, business, new UserIdMatchRequirement());
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Service service = new Service();
            service.BusinessId = business.BusinessId;

            return View(service);
        }

        // POST: BusinessController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateService(Service newService)
        {

            var business = _repo.Business.GetBusiness(newService.BusinessId);
            BusinessInfoViewModel model = new BusinessInfoViewModel(business, _repo);
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, business, new UserIdMatchRequirement());
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            try
            {
                _repo.Service.Create(newService);
                _repo.Save();

                return Info(business.BusinessId);
            }
            catch
            {
                return View("Info", model);
            }
        }

        // GET: BusinessController/Edit/5
        public async Task<IActionResult> EditBusiness(int? id)
        {
            if (id == null)
            {
                return View("Home", "Business");
            }

            var business = _repo.Business.GetBusiness((int)id);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, business, new UserIdMatchRequirement());
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }


            return View(business);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBusiness(Business business)
        {

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, business, new UserIdMatchRequirement());
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            try
            {
                _repo.Business.Update(business);
                _repo.Save();
            }
            catch
            {
                return View("Home", "Business");
            }


            return View("Home", "Business");
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
                return RedirectToAction(nameof(Info));
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
                return RedirectToAction(nameof(Info));
            }
            catch
            {
                return View();
            }
        }
    }
}
