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
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GadeliniumGroupCapstone.Controllers
{
    public class BlockedUsersController : Controller
    {
        
        private IRepositoryWrapper _repo;
        private readonly PetAppDbContext _context;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public BlockedUsersController(PetAppDbContext context, IRepositoryWrapper repo, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _repo = repo;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // GET: BlockedUsers
        public async Task<IActionResult> Index()
        {
            var petAppDbContext = _context.BlockedUsers.Include(b => b.BlockedUserId);
            return View(await petAppDbContext.ToListAsync());
        }

        // GET: BlockedUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blockedUsers = await _context.BlockedUsers
                .Include(b => b.BlockedUserId)
                .FirstOrDefaultAsync(m => m.BlockedUserId == id);
            if (blockedUsers == null)
            {
                return NotFound();
            }

            return View(blockedUsers);

        }

        // GET: BlockedUsers/Create
        public IActionResult Create(int id)
        {

            BlockedUsers blockedUser = new BlockedUsers();
            blockedUser.BlockedUserId = id;

            var petAccountId = _repo.PetAccount.GetPetAccount(id);

            blockedUser.Blockee = petAccountId.UserId;

            blockedUser.BlockerId = _userManager.GetUserId(User);

            _repo.BlockedUser.Create(blockedUser);
            
            _repo.Save();


            return View("Details", blockedUser);
  

        }

        // POST: BlockedUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlockedUsers blockedUsers)
        {
                      
            if (ModelState.IsValid)
            {

                _repo.BlockedUser.Create(blockedUsers);
                _repo.Save();

                return View("Details");

            }

            return View("Details", blockedUsers);
        }

        // GET: BlockedUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blockedUsers = await _context.BlockedUsers.FindAsync(id);
            if (blockedUsers == null)
            {
                return NotFound();
            }
            ViewData["PetAccountId"] = new SelectList(_context.PetAccounts, "PetAccountId", "PetAccountId", blockedUsers.BlockedUserId);
            return View(blockedUsers);
        }

        // POST: BlockedUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlockedUsers blockedUsers)
        {
            if (id != blockedUsers.BlockedUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blockedUsers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlockedUsersExists(blockedUsers.BlockedUserId))
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
            ViewData["PetAccountId"] = new SelectList(_context.PetAccounts, "PetAccountId", "PetAccountId", blockedUsers.BlockedUserId);
            return View(blockedUsers);
        }

        //GET: BlockedUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blockedUsers = await _context.BlockedUsers
                .Include(b => b.BlockedUserId)
                .FirstOrDefaultAsync(m => m.BlockedUserId == id);
            if (blockedUsers == null)
            {
                return NotFound();
            }

            return View(blockedUsers);
        }

        //// POST: BlockedUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blockedUsers = await _context.BlockedUsers.FindAsync(id);
            _context.BlockedUsers.Remove(blockedUsers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlockedUsersExists(int id)
        {
            return _context.BlockedUsers.Any(e => e.BlockedUserId == id);
        }
    }
}
