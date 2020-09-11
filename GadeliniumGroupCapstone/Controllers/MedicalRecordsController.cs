using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GadeliniumGroupCapstone.Data;
using GadeliniumGroupCapstone.Models;
using System.Dynamic;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GadeliniumGroupCapstone.Controllers
{
    public class MedicalRecordsController : Controller
    {
        private readonly PetAppDbContext _context;
        public UserManager<User> _userManager;

        public MedicalRecordsController(PetAppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: MedicalRecords
        public async Task<IActionResult> Index(PetAccount petAccount)
        {
            dynamic myModel = new ExpandoObject();
            myModel.petAccount = petAccount;
            MedicalRecord medicalRecord = _context.MedicalRecords.Where(m => m.PetId == petAccount.PetAccountId).FirstOrDefault();
            if (medicalRecord != null)
            {
                List<Immunization> immunizations = _context.immunizations.Where(i => i.MedicalRecordId == medicalRecord.MedicalRecordId).ToList();
                List<Medication> medications = _context.medications.Where(m => m.MedicalRecordId == medicalRecord.MedicalRecordId).ToList();
                myModel.Immunizations = immunizations;
                myModel.Medications = medications;
            }
            myModel.Record = medicalRecord;
            return View(myModel);
        }

        // GET: MedicalRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecords
                .Include(m => m.PetAccount)
                .FirstOrDefaultAsync(m => m.MedicalRecordId == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            return View(medicalRecord);
        }

        // GET: MedicalRecords/Create
        public IActionResult Create(int petId)
        {
            MedicalRecord medicalRecord = new MedicalRecord();
            medicalRecord.PetId = petId;
            _context.MedicalRecords.Add(medicalRecord);
            _context.SaveChanges();
            return View();
        }

        // POST: MedicalRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicalRecordId,PetId")] MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PetId"] = new SelectList(_context.PetAccounts, "PetAccountId", "PetAccountId", medicalRecord.PetId);
            return View(medicalRecord);
        }

        // GET: MedicalRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecords.FindAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            ViewData["PetId"] = new SelectList(_context.PetAccounts, "PetAccountId", "PetAccountId", medicalRecord.PetId);
            return View(medicalRecord);
        }

        // POST: MedicalRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicalRecordId,PetId")] MedicalRecord medicalRecord)
        {
            if (id != medicalRecord.MedicalRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalRecordExists(medicalRecord.MedicalRecordId))
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
            ViewData["PetId"] = new SelectList(_context.PetAccounts, "PetAccountId", "PetAccountId", medicalRecord.PetId);
            return View(medicalRecord);
        }

        // GET: MedicalRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecords
                .Include(m => m.PetAccount)
                .FirstOrDefaultAsync(m => m.MedicalRecordId == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            return View(medicalRecord);
        }

        // POST: MedicalRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalRecord = await _context.MedicalRecords.FindAsync(id);
            _context.MedicalRecords.Remove(medicalRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalRecordExists(int id)
        {
            return _context.MedicalRecords.Any(e => e.MedicalRecordId == id);
        }
    }
}
