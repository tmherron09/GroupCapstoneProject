using System;
using System.Collections.Generic;
using System.IO;
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

            business.BusinessHour = _repo.BusinessHour.GetBusinessHour(business.BusinessHourId);
            BusinessInfoViewModel model = new BusinessInfoViewModel(business, _repo);

            ViewBag.error = TempData["error"];
            ViewBag.success = TempData["success"];


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
            service.Business = business;
            ServiceWithPhotoUpload serviceToCreate = new ServiceWithPhotoUpload(service);

            return View(serviceToCreate);
        }

        // POST: BusinessController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateService(ServiceWithPhotoUpload newService)
        {

            var business = _repo.Business.GetBusiness(newService.Service.BusinessId);
            BusinessInfoViewModel model = new BusinessInfoViewModel(business, _repo);
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, business, new UserIdMatchRequirement());
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            try
            {
                if (newService.UploadFile == null)
                {
                    byte[] imgdata = await System.IO.File.ReadAllBytesAsync(@"wwwroot\images\Default\default_servicethumbnail.png");
                    PhotoBin logo = new PhotoBin();
                    logo.Content = imgdata;
                    _repo.PhotoBin.Create(logo);
                    _repo.Save();
                }
                else
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await newService.UploadFile.CopyToAsync(memoryStream);
                        newService.Service.ServiceThumbnail = new PhotoBin();
                        newService.Service.ServiceThumbnail.Content = memoryStream.ToArray();

                        //string Base64 = Convert.ToBase64String(newService.Service.ServiceThumbnail.Content);
                        //byte[] array = Convert.FromBase64String(Base64);
                        _repo.PhotoBin.Create(newService.Service.ServiceThumbnail);
                        _repo.Save();
                        // Retrieve photoid just saved to put into service model.
                        
                    }
                }
                newService.Service.PhotoBinId = _repo.PhotoBin.LastPhotoAddedId();

                _repo.Service.Create(newService.Service);
                _repo.Save();

                TempData["success"] = "Service Successfully Added";
                return RedirectToAction("Home");
            }
            catch
            {
                TempData["error"] = "Service failed to create. Try Again.";
                return RedirectToAction("Home");
            }
        }

        public async Task<IActionResult> EditService(int? id)
        {
            if (id == null)
            {
                return View("Home");
            }

            var service = _repo.Service.GetService((int)id);
            var business = _repo.Business.GetBusiness(service.BusinessId);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, business, new UserIdMatchRequirement());
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            service.Business = business;
            service.ServiceThumbnail = _repo.PhotoBin.GetPhoto(service.PhotoBinId);
            ServiceWithPhotoUpload serviceToEdit = new ServiceWithPhotoUpload(service);


            return View(serviceToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditService(ServiceWithPhotoUpload model)
        {
            model.Service.Business = _repo.Business.GetBusiness(model.Service.BusinessId);
            var isAuthorized = await _authorizationService.AuthorizeAsync(User, model.Service.Business, new UserIdMatchRequirement());
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            try
            {
                if (model.UploadFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.UploadFile.CopyToAsync(memoryStream);
                        model.Service.ServiceThumbnail = new PhotoBin();
                        model.Service.ServiceThumbnail.Content = memoryStream.ToArray();

                        //string Base64 = Convert.ToBase64String(model.Service.ServiceThumbnail.Content);
                        //byte[] array = Convert.FromBase64String(Base64);

                        model.Service.ServiceThumbnail.PhotoId = (int)model.Service.PhotoBinId;

                        _repo.PhotoBin.Update(model.Service.ServiceThumbnail);
                        _repo.Save();
                    }
                }

            

                _repo.Service.Update(model.Service);
                _repo.Save();
            }
            catch
            {
                TempData["error"] = "Failed to update Service";
                return RedirectToAction("Home");
            }


            TempData["success"] = "Service Updated";
            return RedirectToAction("Home");
        }


        // GET: BusinessController/Edit/5
        public async Task<IActionResult> EditBusiness(int? id)
        {
            if (id == null)
            {
                return View("Home");
            }

            var business = _repo.Business.GetBusiness((int)id);

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, business, new UserIdMatchRequirement());
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            RegisterEditBusinessViewModel model = new RegisterEditBusinessViewModel(business);
            model.Business.BusinessHour = _repo.BusinessHour.GetBusinessHour(model.Business.BusinessHourId);
            model.Business.BusinessLogo = _repo.PhotoBin.GetPhoto(model.Business.PhotoBinId);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBusiness(RegisterEditBusinessViewModel model)
        {

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, model.Business, new UserIdMatchRequirement());
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            try
            {
                if (model.UploadFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.UploadFile.CopyToAsync(memoryStream);
                        model.PhotoBin.Content = memoryStream.ToArray();

                        string Base64 = Convert.ToBase64String(model.PhotoBin.Content);
                        byte[] array = Convert.FromBase64String(Base64);

                        model.PhotoBin.PhotoId = (int)model.Business.PhotoBinId;

                        _repo.PhotoBin.Update(model.PhotoBin);
                        _repo.Save();
                    }
                }

                _repo.BusinessHour.Update(model.Business.BusinessHour);

                _repo.Business.Update(model.Business);
                _repo.Save();
            }
            catch
            {
                TempData["error"] = "Failed to update Business";
                return RedirectToAction("Home");
            }

            TempData["success"] = "Business Updated";
            return RedirectToAction("Home");
        }

        


        

       


    }
}
