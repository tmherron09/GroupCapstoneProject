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
            PetAccount account = new PetAccount();

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePetAccount(PetAccount petAccount)
        {
            try
            {
                petAccount.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //petAccount.User = _context.Users.Where(u => u.Id == petAccount.UserId).FirstOrDefault();
                _context.PetAccounts.Add(petAccount);
                _context.SaveChanges();
            }
            catch
            {
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

        [HttpPost]
        [ValidateAntiForgeryToken]

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBusinessAccount(Business businessAccount)
        {
            try
            {
                businessAccount.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                businessAccount.User = _context.Users.Where(u => u.Id == businessAccount.UserId).FirstOrDefault();


                byte[] imgdata = await System.IO.File.ReadAllBytesAsync(@"wwwroot\images\Default\default_logo.png");
                PhotoBin logo = new PhotoBin();
                logo.Content = imgdata;
                await _context.PhotoBins.AddAsync(logo);
                await _context.SaveChangesAsync();
                businessAccount.PhotoBinId = _context.PhotoBins.OrderByDescending(p => p.PhotoId).Select(p => p.PhotoId).FirstOrDefault();


                await _context.Businesses.AddAsync(businessAccount);
                await _context.SaveChangesAsync();

            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

            await _userManager.AddClaimAsync(await _userManager.FindByNameAsync(User.Identity.Name), new Claim(ClaimTypes.Role, "Business Owner"));
            await _signInManager.RefreshSignInAsync(await _userManager.FindByNameAsync(User.Identity.Name));
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }

        [HttpGet("Registration/CreateBusinessAccountWithProfileImage")]
        public IActionResult CreateBusinessAccountWithProfileImage()
        {
            RegisterEditBusinessViewModel registerEditBusinessViewModel = new RegisterEditBusinessViewModel();

            return View(registerEditBusinessViewModel);
        }

        [HttpPost("Registration/CreateBusinessAccountWithProfileImage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBusinessAccountWithProfileImage(RegisterEditBusinessViewModel registerEditBusinessViewModel)
        {
            try
            {
                // Get User Id for Business
                registerEditBusinessViewModel.Business.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                registerEditBusinessViewModel.Business.User = _context.Users.Where(u => u.Id == registerEditBusinessViewModel.Business.UserId).FirstOrDefault();

                if (registerEditBusinessViewModel.UploadFile == null)
                {
                    byte[] imgdata = await System.IO.File.ReadAllBytesAsync(@"wwwroot\images\Default\default_logo.png");
                    PhotoBin logo = new PhotoBin();
                    logo.Content = imgdata;
                    await _context.PhotoBins.AddAsync(logo);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    await _uploadImageService.UploadImageCreateRegisterEditBusinessViewModel(registerEditBusinessViewModel);
                }

                registerEditBusinessViewModel.Business.BusinessHourId = _context.BusinessHours.OrderByDescending(p => p.BusinessHourId).Select(p => p.BusinessHourId).FirstOrDefault();
            }
            catch
            {
                // Return Error Page
                ViewBag.error = "Failed to create Account";
                return RedirectToAction("Index", "Home");
            }

            await _context.BusinessHours.AddAsync(registerEditBusinessViewModel.Business.BusinessHour);
            await _context.Businesses.AddAsync(registerEditBusinessViewModel.Business);
            await _userManager.AddClaimAsync(await _userManager.FindByNameAsync(User.Identity.Name), new Claim(ClaimTypes.Role, "Business Owner"));
            await _signInManager.RefreshSignInAsync(await _userManager.FindByNameAsync(User.Identity.Name));
            _context.SaveChanges();
            ViewBag.success = "Business Account Created";

            return RedirectToAction("Index", "Home");
        }


    }
}
