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

namespace GadeliniumGroupCapstone.Controllers
{
    public class PetAccountsController : Controller
    {
        private IRepositoryWrapper _repo;
        private readonly PetAppDbContext _context;

        public PetAccountsController(PetAppDbContext context, IRepositoryWrapper repo)
        {
            _context = context;
            _repo = repo;

        }

        // GET: PetAccounts
        public async Task<IActionResult> Index(int petAccountId)
        {
            var petAppDbContext = _context.PetAccounts.Include(p => p.User);
            return View(await petAppDbContext.ToListAsync());

            //var petAccount = _repo.PetAccount.GetPetAccount(petAccountId);

            ////PetAccountInfoViewModel model = new PetAccountInfoViewModel(petACcount, _repo);


            //return View("Details");

        }

        // GET: PetAccounts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            
            var petAccount = _repo.PetAccount.GetPetAccount(id);

            if (petAccount == null)
            {
                return RedirectToAction("Create");
            }

            return View(petAccount);
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
                return RedirectToAction("Details", petAccount);
            }

            return View(petAccount);
        }

        // GET: PetAccounts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var petAccount = _repo.PetAccount.GetPetAccount(id);

            //if (id == null)
            //{
            //    return NotFound();
            //}


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
                return View(petAccount);
                    
            }


            return View(petAccount);
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


    }
}
