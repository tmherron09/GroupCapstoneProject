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

namespace GadeliniumGroupCapstone.Controllers
{
    public class PetAccountsController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly PetAppDbContext _context;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public PetAccountsController(PetAppDbContext context, IRepositoryWrapper repo, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _repo = repo;
            _userManager = userManager;
            _signInManager = signInManager;
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

            if (petAccount == null)
            {
                return RedirectToAction("Index", "Home");
            }


            return Details();
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

            if(firstPet.Count == 0)
            {
                return View("Index", "PetAccount");
            }
            var pet = firstPet[0];
            return View("Details", pet);

        }

        // GET: PetAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetAccount petAccount)
        {

            if (ModelState.IsValid)
            {
                _repo.PetAccount.Create(petAccount);
                petAccount.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _repo.Save();

                return View("Details", petAccount);
            }

            return await Details(petAccount.PetAccountId);
        }

        // GET: PetAccounts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var petAccount = _repo.PetAccount.GetPetAccount(id);


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
        public async Task<IActionResult> Edit(int id, PetAccount petAccount)
        {
            if (id != petAccount.PetAccountId)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                                
                _repo.PetAccount.Update(petAccount);
                _repo.Save();
                return View("Details", petAccount);
                    
            }


            return View("Details", petAccount);
        }

        // GET: PetAccounts/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var petAccount = _repo.PetAccount.GetPetAccount(id);

            if (id == null)
            {
                return NotFound();
            }

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