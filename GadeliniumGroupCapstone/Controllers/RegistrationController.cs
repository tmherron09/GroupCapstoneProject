using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GadeliniumGroupCapstone.Data;
using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GadeliniumGroupCapstone.Controllers
{
    public class RegistrationController : Controller
    {
        public PetAppDbContext _context;
        public RegistrationController(PetAppDbContext context)
        {
            _context = context;
        }

        // GET: RegistrationController
        public ActionResult PetOwnerRegistration()
        {
            PetAccount account = new PetAccount();
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePetAccount(PetAccount petAccount)
        {
            try
            {
                petAccount.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.PetAccounts.Add(petAccount);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult BusinessRegistration()
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
        public ActionResult CreateBusinessAccount(Business businessAccount)
        {
            try
            {
                businessAccount.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Buisnesses.Add(businessAccount);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationController/Delete/5
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
