
using MediTrack.Data;
using MediTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediTrack.Controllers
{
    public class MedicinesController : Controller
    {
        private readonly MediTrackContext _context;

        public MedicinesController(MediTrackContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var medicines = await _context.Medicines
                .OrderBy(m => m.MedicineName)
                .ToListAsync();

            return View(medicines);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medicine medicine)
        {
            if (!ModelState.IsValid)
                return View(medicine);

            medicine.CreatedAt = DateTime.Now;
            _context.Medicines.Add(medicine);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);

            if (medicine == null)
                return NotFound();

            return View(medicine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Medicine medicine)
        {
            if (id != medicine.MedicineId)
                return NotFound();

            if (!ModelState.IsValid)
                return View(medicine);

            _context.Entry(medicine).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);

            if (medicine == null)
                return NotFound();

            return View(medicine);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);

            if (medicine != null)
            {
                _context.Medicines.Remove(medicine);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
