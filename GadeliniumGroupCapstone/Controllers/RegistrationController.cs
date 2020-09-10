using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GadeliniumGroupCapstone.Data;
using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;

namespace GadeliniumGroupCapstone.Controllers
{
    public class RegistrationController : Controller
    {
        public PetAppDbContext _context;
        public UserManager<User> _userManager;
        public SignInManager<User> _signInManager;
        public RegistrationController(PetAppDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: RegistrationController
        public async Task<ActionResult> PetOwnerRegistration()
        {
            PetAccount account = new PetAccount();
            await _userManager.AddClaimAsync(await _userManager.FindByNameAsync(User.Identity.Name), new Claim(ClaimTypes.Role, "Pet Owner"));
            await _signInManager.RefreshSignInAsync(await _userManager.FindByNameAsync(User.Identity.Name));
            _context.SaveChanges();
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePetAccount(PetAccount petAccount)
        {
            petAccount.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            petAccount.User = _context.Users.Where(u => u.Id == petAccount.UserId).FirstOrDefault();
            _context.PetAccounts.Add(petAccount);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        } 

        public async Task<ActionResult> BusinessRegistration()
        {
            Business business = new Business();
            await _userManager.AddClaimAsync(await _userManager.FindByNameAsync(User.Identity.Name), new Claim(ClaimTypes.Role, "Business Owner"));
            await _signInManager.RefreshSignInAsync(await _userManager.FindByNameAsync(User.Identity.Name));
            _context.SaveChanges();
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
        public ActionResult CreateBusinessAccount(Business businessAccount)
        {
            businessAccount.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            businessAccount.User = _context.Users.Where(u => u.Id == businessAccount.UserId).FirstOrDefault();
            _context.Buisnesses.Add(businessAccount);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
