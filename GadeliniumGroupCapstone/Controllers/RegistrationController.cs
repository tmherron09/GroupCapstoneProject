using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GadeliniumGroupCapstone.Contracts;
using GadeliniumGroupCapstone.Data;
using GadeliniumGroupCapstone.Models;
using GadeliniumGroupCapstone.UploadImage;
using GadeliniumGroupCapstone.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace GadeliniumGroupCapstone.Controllers
{
    public class RegistrationController : Controller
    {
        public PetAppDbContext _context;
        private IRepositoryWrapper _repo;
        public UserManager<User> _userManager;
        public SignInManager<User> _signInManager;
        private UploadImageService _uploadImageService;
        public RegistrationController(PetAppDbContext context, IRepositoryWrapper repo, UserManager<User> userManager, SignInManager<User> signInManager, UploadImageService uploadImageService)
        {
            _context = context;
            _repo = repo;
            _userManager = userManager;
            _signInManager = signInManager;
            _uploadImageService = uploadImageService;
        }

        // GET: RegistrationController
        public IActionResult PetOwnerRegistration()
        {
            PetWithImage account = new PetWithImage();

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePetAccount(PetWithImage model)
        {
            try
            {
                model.PetAccount.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await _uploadImageService.CreatePetAccountUploadImage(model);


                _repo.PetAccount.Create(model.PetAccount);
                _repo.Save();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                ViewBag.error = "Failed to create Account";
                return RedirectToAction("Index", "Home");
            }
            await _userManager.AddClaimAsync(await _userManager.FindByNameAsync(User.Identity.Name), new Claim(ClaimTypes.Role, "Pet Owner"));
            await _signInManager.RefreshSignInAsync(await _userManager.FindByNameAsync(User.Identity.Name));
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult BusinessRegistration()
        {
            Business business = new Business();

            return View(business);
        }



        //// POST: RegistrationController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateBusinessAccount(Business businessAccount)
        //{
        //    try
        //    {
        //        businessAccount.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        businessAccount.User = _context.Users.Where(u => u.Id == businessAccount.UserId).FirstOrDefault();


        //        byte[] imgdata = await System.IO.File.ReadAllBytesAsync(@"wwwroot\images\Default\default_logo.png");
        //        PhotoBin logo = new PhotoBin();
        //        logo.Content = imgdata;
        //        await _context.PhotoBins.AddAsync(logo);
        //        await _context.SaveChangesAsync();
        //        businessAccount.PhotoBinId = _context.PhotoBins.OrderByDescending(p => p.PhotoId).Select(p => p.PhotoId).FirstOrDefault();


        //        await _context.Businesses.AddAsync(businessAccount);
        //        await _context.SaveChangesAsync();

        //    }
        //    catch
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    await _userManager.AddClaimAsync(await _userManager.FindByNameAsync(User.Identity.Name), new Claim(ClaimTypes.Role, "Business Owner"));
        //    await _signInManager.RefreshSignInAsync(await _userManager.FindByNameAsync(User.Identity.Name));
        //    _context.SaveChanges();


        //    return RedirectToAction("Index", "Home");
        //}


        //[Route("{controller}/Business")]
        //[Route("{controller}/CreateBusiness")]
        //[Route("Business/CreateBusiness")]
        [HttpGet("Registration/CreateBusinessAccountWithProfileImage")]
        public IActionResult CreateBusinessAccountWithProfileImage()
        {
            if(_repo.Business.UserHasBusiness(User.FindFirstValue(ClaimTypes.NameIdentifier)))
            {
                return RedirectToAction("Home", "Business");
            }

            RegisterEditBusinessViewModel regEditModel = new RegisterEditBusinessViewModel();

            return View("CreateBusinessAccountWithProfileImage", regEditModel);
        }

        [HttpPost("Registration/CreateBusinessAccountWithProfileImage")]
        //[HttpPost("Registration/CreateBusiness")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBusinessAccountWithProfileImage(RegisterEditBusinessViewModel regEditModel)
        {
            try
            {
                // Get User Id for Business
                regEditModel.Business.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await _uploadImageService.RegisterBusinessUploadImage(regEditModel);

                regEditModel.Business.BusinessHourId = _context.BusinessHours.OrderByDescending(p => p.BusinessHourId).Select(p => p.BusinessHourId).FirstOrDefault();
            }
            catch
            {
                // Return Error Page
                ViewBag.error = "Failed to create Account";
                return RedirectToAction("Index", "Home");
            }

            await _context.BusinessHours.AddAsync(regEditModel.Business.BusinessHour);
            await _context.Businesses.AddAsync(regEditModel.Business);
            await _userManager.AddClaimAsync(await _userManager.FindByNameAsync(User.Identity.Name), new Claim(ClaimTypes.Role, "Business Owner"));
            await _signInManager.RefreshSignInAsync(await _userManager.FindByNameAsync(User.Identity.Name));
            _context.SaveChanges();
            ViewBag.success = "Business Account Created";

            return RedirectToAction("Index", "Home");
        }


    }
}
