using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GadeliniumGroupCapstone.Data;
using GadeliniumGroupCapstone.Models;
using GadeliniumGroupCapstone.Contracts;
using System.Security.Claims;

namespace GadeliniumGroupCapstone.Controllers
{
    public class PetBiosController : Controller
    {
        private readonly PetAppDbContext _context;
        private IRepositoryWrapper _repo;

        
        public PetBiosController(PetAppDbContext context, IRepositoryWrapper repo)
        {
            _context = context;
            _repo = repo;

        }

        // GET: PetBios
        public async Task<IActionResult> Index()
        {
            
            return RedirectToAction("Details");
        }

        // GET: PetBios/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var petbioId = _repo.PetAccount.GetPetBioId(id);

            var petBio = _repo.PetBio.GetPetBioAccount(petbioId);

            if (petBio == null)
            {
                return RedirectToAction("Create", new { petAccountid = id });
            }


            return View(petBio);
        }

        // GET: PetBios/Create
        public IActionResult Create(int petAccountid)
        {
            PetBio petBio = new PetBio();
            petBio.PetId = petAccountid;


            return View(petBio);
        }

        // POST: PetBios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetBio petBio)
        {


            //petBio.PetAccount = _repo.PetBio.GetAssociatedPet(petBio.PetBioId);
            

            if (ModelState.IsValid)
            {
                _repo.PetBio.Create(petBio);
                _repo.Save();
                return RedirectToAction("Details", new { id = petBio.PetId });
            }
            

            return View(petBio);
        }

        // GET: PetBios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            
            
            if (id == null)
            {
                return NotFound();
            }

            var petBio = await _context.PetBios.FindAsync(id);
            if (petBio == null)
            {
                return NotFound();
            }


            petBio.PetAccount = _repo.PetBio.GetAssociatedPet(petBio.PetBioId);
            
            
            return View(petBio);
        }

        // POST: PetBios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PetBio petBio)
        {
            
            
            if (id != petBio.PetBioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petBio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetBioExists(petBio.PetBioId))
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
            //ViewData["PetId"] = new SelectList(_context.PetAccounts, "PetAccountId", "PetAccountId", petBio.PetId);
            return View(petBio);
        }

        // GET: PetBios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petBio = await _context.PetBios
                .Include(p => p.PetAccount)
                .FirstOrDefaultAsync(m => m.PetBioId == id);
            if (petBio == null)
            {
                return NotFound();
            }

            return View(petBio);
        }

        // POST: PetBios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var petBio = await _context.PetBios.FindAsync(id);
            _context.PetBios.Remove(petBio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetBioExists(int id)
        {
            return _context.PetBios.Any(e => e.PetBioId == id);
        }
    }
}
