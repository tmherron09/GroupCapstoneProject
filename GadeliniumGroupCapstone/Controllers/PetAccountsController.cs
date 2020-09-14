using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GadeliniumGroupCapstone.Data;
using GadeliniumGroupCapstone.Models;
using System.Security.Claims;
using GadeliniumGroupCapstone.Contracts;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using GadeliniumGroupCapstone.AuthorizationPolicies;
using SQLitePCL;
using Microsoft.AspNetCore.Identity;
using GadeliniumGroupCapstone.ViewModels;
using GadeliniumGroupCapstone.UploadImage;

namespace GadeliniumGroupCapstone.Controllers
{
    public class PetAccountsController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly PetAppDbContext _context;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private UploadImageService _uploadImageService;

        public PetAccountsController(PetAppDbContext context, IRepositoryWrapper repo, UserManager<User> userManager, SignInManager<User> signInManager, UploadImageService uploadImageService)
        {
            _context = context;
            _repo = repo;
            _userManager = userManager;
            _signInManager = signInManager;
            _uploadImageService = uploadImageService;
        }

        [Route("{controller}/")]
        [Route("{controller}/Home")]
        public IActionResult Home()
        {
            if(!IsPetOwnerOrSignerIn())
            {
                return RedirectToAction("Index", "Home");
            }

            var userdId = _userManager.GetUserId(User);

            var petAccount = _repo.PetAccount.GetPetAccountOfUserId(userdId);
            
            foreach(var pet in petAccount)
            {
                pet.PetProfileImage = _repo.PhotoBin.GetPhoto(pet.PhotoBinId);
            }

            if (petAccount == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Index", petAccount);
        }

        // GET: PetAccounts
        [Route("{controller}/Index")]
        public async Task<IActionResult> Index(int petAccountId)
        {
            var petAppDbContext = _context.PetAccounts.Include(p => p.User);
            return View(await petAppDbContext.ToListAsync());
        }

        // GET: PetAccounts/Details/5
        [Route("{controller}/Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            
            var petAccount = _repo.PetAccount.GetPetAccount(id);
            var userId = _userManager.GetUserId(User);

            if (petAccount == null)
            {
                return RedirectToAction("Create");
            }

            petAccount.PetProfileImage = _repo.PhotoBin.GetPhoto(petAccount.PhotoBinId);

            return View(petAccount);
        }

        [Route("{controller}/Details")]
        public IActionResult Details()
        {
            if (!IsPetOwnerOrSignerIn())
            {
                return View("Index", "PetAccount");
            }

            var userId = _userManager.GetUserId(User);
            var firstPet = _repo.PetAccount.GetPetAccountOfUserId(userId);

            if(firstPet.Count() == 0)
            {
                return View("Index", "PetAccount");
            }
            var pet = firstPet[0];
            pet.PetProfileImage = _repo.PhotoBin.GetPhoto(pet.PhotoBinId);
            return View("Details", pet);

        }

        public IActionResult SearchPets()
        {
            return View();

        }
        // GET: PetAccounts/Create
        public IActionResult Create()
        {
            PetWithImage account = new PetWithImage();

            return View(account);
        }

        // POST: PetAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetWithImage model)
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

            return RedirectToAction("Index", "PetAccounts");
        }

        // GET: PetAccounts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var petAccount = _repo.PetAccount.GetPetAccount(id);
            PetWithImage account = new PetWithImage(petAccount);


            if (petAccount == null)
            {
                return NotFound();
            }

            return View(petAccount);
        }

        // POST: PetAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PetWithImage model)
        {
            

            if (ModelState.IsValid)
            {

                _uploadImageService.EditPetAccountUploadImage(model);



                _repo.PetAccount.Update(model.PetAccount);
                _repo.Save();
                return View("Details", model.PetAccount);
                    
            }


            return View("Details", model.PetAccount);
        }

        // GET: PetAccounts/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petAccount = _repo.PetAccount.GetPetAccount(id);

            

            return View(petAccount);
        }

        // POST: PetAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petAccount = _repo.PetAccount.GetPetAccount(id);

            _repo.PetAccount.Delete(petAccount);
            
            _repo.Save();

            return RedirectToAction(nameof(Index));

        }


        // Method to Test if Signed in and Pet Account Owner
        private bool IsPetOwnerOrSignerIn()
        {
            if (!User.IsInRole("Pet Owner"))
            {
                return false;
            }
            else if (!_signInManager.IsSignedIn(User))
            {
                return false;
            }
            return true;
        }

        //get
        public async Task<IActionResult> Block(int id)
        {

            var petAccount = _repo.PetAccount.GetPetAccount(id);

            return View(petAccount);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Block()
        {



        }




    }
}