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
            var petAppDbContext = _context.BlockedUsers.Include(b => b.PetAccount);
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
                .Include(b => b.PetAccount)
                .FirstOrDefaultAsync(m => m.BlockedUserID == id);
            if (blockedUsers == null)
            {
                return NotFound();
            }

            return View(blockedUsers);

        }

        // GET: BlockedUsers/Create
        public IActionResult Create(int id)
        {

            BlockedUsers blockedUsers = new BlockedUsers();
            //blockedUsers.BlockedUserID = id;
            //blockedUsers.PetAccountId = _repo.PetAccount.GetPetAccount(id);
            
            //passed through from the DETAILS view of PetAccounts -> will capture the petId as an "int" through here.

            //ViewData["PetAccountId"] = new SelectList(_context.PetAccounts, "PetName", "PetName");

            return View();
            
        }

        // POST: BlockedUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlockedUsers blockedUsers)
        {

            //BlockedUsers blockedUsers = new BlockedUsers();
            //blockedUsers.BlockedUserID = id;

            //ViewData["PetAccountId"] = new SelectList(_context.PetAccounts, "PetName", "PetName");

            //SelectList listOfNames = new SelectList(_context.PetAccounts, "PetName", "PetName");

            //var selected = listOfNames.Where(s => s.Value == "selectedValue").First();

            //selected.Selected = true;

            //blockedUser.PetAccountId = _context.PetAccounts.Where(p => p.PetAccountId == id);



            //string chosenUser1 = _repo.PetAccount.GetPetAccount(id);

            //ViewData["PetAccountId"] 
            
            //var chosenUser = _repo.BlockedUser.GetBlockedUserId();


            //if (ModelState.IsValid)
            //{
            //    _repo.BlockedUser.CreateBlockUser(chosenUser);
            //    _repo.Save();

            //    return View("Details");

            //}

            return View("Details");
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
            ViewData["PetAccountId"] = new SelectList(_context.PetAccounts, "PetAccountId", "PetAccountId", blockedUsers.PetAccountId);
            return View(blockedUsers);
        }

        // POST: BlockedUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlockedUserID,PetAccountId")] BlockedUsers blockedUsers)
        {
            if (id != blockedUsers.BlockedUserID)
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
                    if (!BlockedUsersExists(blockedUsers.BlockedUserID))
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
            ViewData["PetAccountId"] = new SelectList(_context.PetAccounts, "PetAccountId", "PetAccountId", blockedUsers.PetAccountId);
            return View(blockedUsers);
        }

        // GET: BlockedUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blockedUsers = await _context.BlockedUsers
                .Include(b => b.PetAccount)
                .FirstOrDefaultAsync(m => m.BlockedUserID == id);
            if (blockedUsers == null)
            {
                return NotFound();
            }

            return View(blockedUsers);
        }

        // POST: BlockedUsers/Delete/5
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
            return _context.BlockedUsers.Any(e => e.BlockedUserID == id);
        }
    }
}
