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

namespace GadeliniumGroupCapstone.Controllers
{
    public class PetAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IRepositoryWrapper _repo;

        public PetAccountsController(ApplicationDbContext context, IRepositoryWrapper repo)
        {
            _context = context;

                _repo = repo;


        }

        // GET: PetAccounts
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.PetAccounts.Include(p => p.User);
            //return View(await applicationDbContext.ToListAsync());

            return RedirectToAction("Details");
        }

        // GET: PetAccounts/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var petAccount = _repo.PetAccount.GetPetAccount(id);

            return View(petAccount);
        }

        // GET: PetAccounts/Create
        public IActionResult Create()
        {
            //ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
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
                _context.Add(petAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", petAccount.UserId);
            return View(petAccount);
        }

        // GET: PetAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petAccount = await _context.PetAccounts.FindAsync(id);
            if (petAccount == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", petAccount.UserId);
            return View(petAccount);
        }

        // POST: PetAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetAccountId,Breed,Species,PetName,Dob,AnimalType,PetPhone,UserId")] PetAccount petAccount)
        {
            if (id != petAccount.PetAccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetAccountExists(petAccount.PetAccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", petAccount.UserId);
            return View(petAccount);
        }

        // GET: PetAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petAccount = await _context.PetAccounts
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.PetAccountId == id);
            if (petAccount == null)
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
            var petAccount = await _context.PetAccounts.FindAsync(id);
            _context.PetAccounts.Remove(petAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetAccountExists(int id)
        {
            return _context.PetAccounts.Any(e => e.PetAccountId == id);
        }

    }
}
