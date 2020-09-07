using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GadeliniumGroupCapstone.Data;
using GadeliniumGroupCapstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GadeliniumGroupCapstone.AuthorizationPolicies;

namespace GadeliniumGroupCapstone.Controllers
{
    public class PetAccountsController : Controller
    {
        private readonly SiteUserContext _context;
        IAuthorizationService _authorizationService;
        UserManager<SiteUser> _userManager;

        public PetAccountsController(SiteUserContext context, IAuthorizationService authorizationService, UserManager<SiteUser> userManager)
        {
            _context = context;
            _authorizationService = authorizationService;
            _userManager = userManager;
        }

        // GET: PetAccounts
        public async Task<IActionResult> Index()
        {
            
            var siteUserContext = _context.PetAccounts.Include(p => p.SiteUser);
            return View(await siteUserContext.ToListAsync());
        }

        // GET: PetAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petAccount = await _context.PetAccounts
                .Include(p => p.SiteUser)
                .FirstOrDefaultAsync(m => m.PetAccountId == id);
            if (petAccount == null)
            {
                return NotFound();
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
        public async Task<IActionResult> Create([Bind("PetAccountId,Breed,Species,PetName,Dob,AnimalType,PetPhone")] PetAccount petAccount)
        {
            if (ModelState.IsValid)
            {
                
                petAccount.SiteUserId = _userManager.GetUserId(User);

                var isAuthorized = await _authorizationService.AuthorizeAsync(User, petAccount, new UserIdMatchRequirement());
                if(!isAuthorized.Succeeded)
                {
                    return Forbid();
                }
                _context.Add(petAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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

            var isAuthorized = await _authorizationService.AuthorizeAsync(User, petAccount, new UserIdMatchRequirement());

            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            
            return View(petAccount);
        }

        // POST: PetAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PetAccountId,Breed,Species,PetName,Dob,AnimalType,PetPhone,SiteUserId")] PetAccount petAccount)
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
            ViewData["SiteUserId"] = new SelectList(_context.SiteUsers, "Id", "Id", petAccount.SiteUserId);
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
                .Include(p => p.SiteUser)
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
